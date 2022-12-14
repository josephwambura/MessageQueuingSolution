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

            MessageQueue msgQ = new MessageQueue(".\\Private$\\billpay");
            msgQ.Send(msg);
        }

        private void buttonProcessPayment_Click(object sender, EventArgs e)
        {

        }
    }

    public struct Payment
    {
        public string Payor, Payee;
        public decimal Amount;
        public string DueDate;
    }
}
