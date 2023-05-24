using System.Data;
using System.Diagnostics.Metrics;
using Calculator_2._0;
namespace Calculator_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {InitializeComponent();}
        private void add_to_input(object sender, EventArgs e) //Skriver till input lable
        {
            Button currentButton = (Button)sender;
            string text_to_add = currentButton.Text;
            if (text_to_add.Contains("(^X)")) //Låter användaren fylla i värdet av X
            { text_to_add = "(^"; }
            user_input_box.Text = user_input_box.Text + text_to_add;    
        }

        private void solve_button_Click(object sender, EventArgs e) //Funktion för att läsa av nummer och beräkna tal
        {
            string string_to_calculate = user_input_box.Text;
            if (string_to_calculate.Contains("π")) //Ersätter π med sitt värde
            {
                string_to_calculate = string_to_calculate.Replace("π", "3.14159265359");
            }
            if (string_to_calculate.Contains("(^")) //Kollar om input inehåller exponent och skickar isåfall till solve fil
            {
                string_to_calculate = Solve.Power(string_to_calculate);
            }
            if (string_to_calculate.Contains("√")) //Kollar om input inehåller roten ur och skickar isåfall till solve fil
            {
                string_to_calculate = Solve.Root(string_to_calculate);
            }
            try
            {
            string output = new DataTable().Compute(string_to_calculate, null).ToString();
            user_output_box.Text = output.Replace(",", "."); //Byter ut , med .
            }
        catch
            { user_output_box.Text = "ERROR"; }
        }

        private void clear_button_Click(object sender, EventArgs e) //Tömmer input label
        {user_input_box.Text = "";}
        
        private void user_ans_button_Click(object sender, EventArgs e) //Skriver in tidigare svar i input label
        {user_input_box.Text = user_input_box.Text + user_output_box.Text;}

        private void prime_calculator(object sender, EventArgs e) //Funktion som skickar till prime_solve 
        {
            string number_to_calculate = prime_input.Text;

            (string result, string dividers) = Prime_solver.Calculate(number_to_calculate);
            deviders_text_box.Text = "Dividers: " + dividers;
            result_text_box.Text = result;
        }
    }
}