using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace TestRegex
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Define a regular expression
            try
            {
                Regex rx = new Regex(txtRegex.Text, RegexOptions.Compiled | RegexOptions.IgnoreCase);


                // Find matches.
                MatchCollection matches = rx.Matches(txtSource.Text);

                txtMatch.Text = "";

                foreach (Match match in matches)
                {
                    // Report the number of matches found.
                    //Console.WriteLine("{0} matches found in: {1} value: {2}\n", matches.Count, txtSource.Text, match.Groups[1].ToString());

                    //txtMatch.Text = match.Groups[1].ToString();

                    

                    for (int i = 1; i < match.Groups.Count; i++)
                    {
                        var group = match.Groups[i];
                        if (group.Success)
                            txtMatch.Text = txtMatch.Text + "Group: " + rx.GroupNameFromNumber(i) + "  Value: " + match.Groups[i].ToString() + "\r\n";

                    }

                }
            }
            catch(Exception x)
            {
                // Catch the exception and display the error message.
                MessageBox.Show(x.Message, "Oops.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }



        private void txtMatch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string strStorefrontOrderID;
            string strItemDataXMLFullName;

            txtMatch.Text = "";

            strItemDataXMLFullName = txtSource.Text;
            
            int iFirstIndex = strItemDataXMLFullName.LastIndexOf("Order.") + 6;
            int iLastIndex = strItemDataXMLFullName.LastIndexOf(".ItemData.");
            if (iFirstIndex != -1 && iLastIndex != -1)
            {
                int iSubstringLength = iLastIndex - iFirstIndex;
                strStorefrontOrderID = strItemDataXMLFullName.Substring(iFirstIndex, iSubstringLength);
                txtMatch.Text = strStorefrontOrderID.ToString();
            }
            else
            {
                txtMatch.Text = "No Match";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strItemDataXMLFullName;
            string[] strArrValues;

            strItemDataXMLFullName = "Order.20250624.ItemData.20152334.xml";
            

            strArrValues = strItemDataXMLFullName.Split('.');
            if (strArrValues.Length > 0)
            {
                txtMatch.Text = strArrValues[1];
            }
            
        }
    }
}
