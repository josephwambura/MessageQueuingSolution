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
        string queuePath = ".\\Private$\\billpay";

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonSendPayment_Click(object sender, EventArgs e)
        {
            Payment myPayment;
            myPayment.Payor = textBoxYourName.Text;
            myPayment.Payee = textBoxPayTo.Text;
            myPayment.Amount = Convert.ToDecimal(textBoxAmount.Text);
            myPayment.DueDate = dateTimePickerDueDate.Text;

            System.Messaging.Message msg = new System.Messaging.Message
            {
                Body = myPayment
            };

            MessageQueue msgQ;
            if (MessageQueue.Exists(queuePath) == false)
            {
                //Queue does not exist so create it
                msgQ = MessageQueue.Create(queuePath);
            }
            else
            {
                msgQ = new MessageQueue(queuePath);
            }

            msgQ.Send(msg);
        }

        private void buttonProcessPayment_Click(object sender, EventArgs e)
        {
            MessageQueue msgQ;
            if (MessageQueue.Exists(queuePath) == false)
            {
                //Queue does not exist so create it
                msgQ = MessageQueue.Create(queuePath);
            }
            else
            {
                msgQ = new MessageQueue(queuePath);
            }

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

    public struct Payment
    {
        public string Payor, Payee;
        public decimal Amount;
        public string DueDate;
    }
}
