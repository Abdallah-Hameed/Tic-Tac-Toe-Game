using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_XO
{
    public partial class frmSpaceXO : Form
    {
        public frmSpaceXO()
        {
            InitializeComponent();
        }

        enum enWinner { Player1 , Player2 , Draw , InProgress}

        struct stGameStatus
        {
            public enWinner Winner;

            public bool GameOver;

            public short PlayCounter;
        }

        stGameStatus GameStatus;

        public void ChangePlayerTurn()
        {
            if (lblPlayerTurn.Text == "Player 1")
            {
                lblPlayerTurn.Text = "Player 2";
            }

            else if (lblPlayerTurn.Text == "Player 2")
            {
                lblPlayerTurn.Text = "Player 1";
            }
        }

        public void ChangeImage(Button btn)
        {
             GameStatus.PlayCounter++;

            if (lblPlayerTurn.Text == "Player 1")
            {
                btn.BackgroundImage = Properties.Resources.X;

                btn.Tag = "X";

                btn.Enabled = false;
            }

            if (lblPlayerTurn.Text == "Player 2")
            {
                btn.BackgroundImage = Properties.Resources.O;

                btn.Tag = "O";

                btn.Enabled = false;
            }

            if (GameStatus.PlayCounter >= 9)
            {
                GameStatus.GameOver =true;

                GameStatus.Winner = enWinner.Draw;

                lblPlayerTurn.Text = "DRAW";

                EndGame();
            }
        }

        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.YellowGreen;

                btn2.BackColor = Color.YellowGreen;

                btn3.BackColor = Color.YellowGreen;

                GameStatus.GameOver = true;

                if(btn1.Tag.ToString() =="X")
                {
                    GameStatus.Winner = enWinner.Player1;

                    lblWinner.Text = "Player 1";

                    lblPlayerTurn.Text = "GAME OVER";

                    EndGame();

                    return true;
                }

                else
                {
                    GameStatus.Winner = enWinner.Player2;

                    lblWinner.Text = "Player 2";

                    lblPlayerTurn.Text = "GAME OVER";

                    EndGame();

                    return true;
                }
            }

            return false;
        }

        public void Check()
        {
            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button3, button6, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;
        }

        public void DisableButtons()
        {
            button1.Enabled = false;

            button2.Enabled = false;

            button3.Enabled = false;

            button4.Enabled = false;

            button5.Enabled = false;

            button6.Enabled = false;

            button7.Enabled = false;

            button8.Enabled = false;

            button9.Enabled = false;
        }

        public void EnableButtons()
        {
            button1.Enabled = true;

            button2.Enabled = true;

            button3.Enabled = true;

            button4.Enabled = true;

            button5.Enabled = true;

            button6.Enabled = true;

            button7.Enabled = true;

            button8.Enabled = true;

            button9.Enabled = true;
        }

        public void EndGame()
        {
            GameStatus.GameOver = true;

            switch(GameStatus.Winner)
            {
                case enWinner.Player1:
                {
                    lblWinner.Text = "Player 1";

                    MessageBox.Show("Wiiner Is Player 1", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    DisableButtons();

                    break;
                }

                case enWinner.Player2:
                {
                    lblWinner.Text = "Player 2";

                    MessageBox.Show("Wiiner Is Player 2", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    DisableButtons();

                    break;
                }

                default:
                {
                    lblWinner.Text = "Draw";  

                    MessageBox.Show("DRAW", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    DisableButtons();

                    break;
                }
            }
        }

        public void DefaultSettingsOfButtons()
        {
            button1.BackgroundImage = Properties.Resources.question_mark_96;
            button1.BackColor = Color.Transparent;
            button1.Tag = "?";


            button2.BackgroundImage = Properties.Resources.question_mark_96;
            button2.BackColor = Color.Transparent;
            button2.Tag = "?";


            button3.BackgroundImage = Properties.Resources.question_mark_96;
            button3.BackColor = Color.Transparent;
            button3.Tag = "?";


            button4.BackgroundImage = Properties.Resources.question_mark_96;
            button4.BackColor = Color.Transparent;
            button4.Tag = "?";


            button5.BackgroundImage = Properties.Resources.question_mark_96;
            button5.BackColor = Color.Transparent;
            button5.Tag = "?";


            button6.BackgroundImage = Properties.Resources.question_mark_96;
            button6.BackColor = Color.Transparent;
            button6.Tag = "?";


            button7.BackgroundImage = Properties.Resources.question_mark_96;
            button7.BackColor = Color.Transparent;
            button7.Tag = "?";


            button8.BackgroundImage = Properties.Resources.question_mark_96;
            button8.BackColor = Color.Transparent;
            button8.Tag = "?";


            button9.BackgroundImage = Properties.Resources.question_mark_96;
            button9.BackColor = Color.Transparent;
            button9.Tag = "?";
        }

        public void RestartGame()
        {
            EnableButtons();

            DefaultSettingsOfButtons();

            GameStatus.GameOver = false;

            GameStatus.Winner = enWinner.InProgress;

            lblPlayerTurn.Text = "Player 1";

            lblWinner.Text = "In Progress";

            GameStatus.PlayCounter = 0;
        }

        public void Click(object sender)
        {
            ChangeImage((Button)sender);

            ChangePlayerTurn();

            Check();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Click(sender);
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}