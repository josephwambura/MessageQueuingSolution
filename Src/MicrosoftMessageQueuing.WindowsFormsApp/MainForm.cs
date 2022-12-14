using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicrosoftMessageQueuing.WindowsFormsApp
{
    public partial class FormMain : Form
    {
        private readonly string _queuePath = ".\\Private$\\billpay";

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonSendPayment_Click(object sender, EventArgs e)
        {
            Payment myPayment;

            if (string.IsNullOrWhiteSpace(textBoxYourName.Text)
                || string.IsNullOrWhiteSpace(textBoxPayTo.Text)
                || string.IsNullOrWhiteSpace(textBoxAmount.Text)
                || string.IsNullOrWhiteSpace(dateTimePickerDueDate.Text))
            {
                return;
            }

            myPayment.Payor = textBoxYourName.Text;
            myPayment.Payee = textBoxPayTo.Text;
            myPayment.Amount = Convert.ToDecimal(textBoxAmount.Text);
            myPayment.DueDate = dateTimePickerDueDate.Text;

            System.Messaging.Message msg = new System.Messaging.Message
            {
                Body = myPayment
            };

            MessageQueue msgQ = GetMessageQueue(_queuePath);

            msgQ.Send(msg);

            loadListBoxWithMessages();
        }

        private void buttonProcessPayment_Click(object sender, EventArgs e)
        {
            MessageQueue msgQ = GetMessageQueue(_queuePath);

            Payment myPayment = new Payment();
            object o = new object();
            Type[] arrTypes = new Type[2];
            arrTypes[0] = myPayment.GetType();
            arrTypes[1] = o.GetType();
            msgQ.Formatter = new XmlMessageFormatter(arrTypes);

            try
            {
                myPayment = (Payment)msgQ.Receive(new TimeSpan(0, 0, 30)).Body;

                StringBuilder sb = new StringBuilder();
                sb.Append("Payment paid to: " + myPayment.Payor);
                sb.Append("\n");
                sb.Append("Paid by: " + myPayment.Payee);
                sb.Append("\n");
                sb.Append("Amount: Ksh. " + myPayment.Amount.ToString());
                sb.Append("\n");
                sb.Append("Due Date: " + Convert.ToDateTime(myPayment.DueDate));

                MessageBox.Show(sb.ToString(), "Message Received!");

                loadListBoxWithMessages();
            }
            catch (MessageQueueException ex)
            {

                //throw;
                MessageBox.Show(ex.ToString(), "MessageQueueException receiving message!");
            }
            catch (Exception ex)
            {

                //throw;
                MessageBox.Show(ex.ToString(), "Exception receiving message!");
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            loadListBoxWithMessages();
        }

        private void loadListBoxWithMessages()
        {
            MessageQueue msgQ = GetMessageQueue(_queuePath);

            listBoxQueues.BeginUpdate();
            listBoxQueues.DataSource = msgQ.GetAllMessages().ToList();
            listBoxQueues.ValueMember = "Id";
            listBoxQueues.DisplayMember = "MessageType";
            listBoxQueues.EndUpdate();
        }

        private void listBoxQueues_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show($"Are you sure you want to receive the message - {((System.Messaging.Message)listBoxQueues.SelectedItem).Id}?", "Receive the Message!", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                MessageQueue msgQ = GetMessageQueue(_queuePath);

                Payment myPayment = new Payment();
                object o = new object();
                Type[] arrTypes = new Type[2];
                arrTypes[0] = myPayment.GetType();
                arrTypes[1] = o.GetType();
                msgQ.Formatter = new XmlMessageFormatter(arrTypes);

                try
                {
                    myPayment = (Payment)msgQ.ReceiveById(((System.Messaging.Message)listBoxQueues.SelectedItem).Id, new TimeSpan(0, 0, 30)).Body;

                    StringBuilder sb = new StringBuilder();
                    sb.Append("Payment paid to: " + myPayment.Payor);
                    sb.Append("\n");
                    sb.Append("Paid by: " + myPayment.Payee);
                    sb.Append("\n");
                    sb.Append("Amount: Ksh. " + myPayment.Amount.ToString());
                    sb.Append("\n");
                    sb.Append("Due Date: " + Convert.ToDateTime(myPayment.DueDate));

                    MessageBox.Show(sb.ToString(), "Message Received!");

                    loadListBoxWithMessages();
                }
                catch (MessageQueueException ex)
                {

                    //throw;
                    MessageBox.Show(ex.ToString(), "MessageQueueException receiving message!");
                }
                catch (Exception ex)
                {

                    //throw;
                    MessageBox.Show(ex.ToString(), "Exception receiving message!");
                }
            }
        }

        private static MessageQueue GetMessageQueue(string queuePath)
        {
            if (MessageQueue.Exists(queuePath) == false)
            {
                //Queue does not exist so create it
                return MessageQueue.Create(queuePath);
            }
            else
            {
                return new MessageQueue(queuePath);
            }
        }
    }

    public struct Payment
    {
        public string Payor, Payee;
        public decimal Amount;
        public string DueDate;
    }
}
