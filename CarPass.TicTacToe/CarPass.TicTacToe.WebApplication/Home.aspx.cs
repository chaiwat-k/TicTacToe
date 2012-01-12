using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarPass.TicTacToe.Process;

namespace CarPass.TicTacToe.WebApplication
{
    public partial class Home : PageBase
    {
        public TicTacToePresenter ThePresenter
        {
            get
            {
                return (TicTacToePresenter)Session[Prefix + "_ThePresenter"];
            }
            internal set
            {
                Session[Prefix + "_ThePresenter"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               if(ThePresenter == null)
                    ThePresenter=new TicTacToePresenter();
            }
        }

        protected override void BindModel()
        {

            MsgLabel.Text = ThePresenter.Message;
            TimeLabel.Text = ThePresenter.GameDuration;

            LB0.ImageUrl = GetImageUrl(ThePresenter.GridValues[0, 0]);
            LB1.ImageUrl = GetImageUrl(ThePresenter.GridValues[1, 0]);
            LB2.ImageUrl = GetImageUrl(ThePresenter.GridValues[2, 0]);
            LB3.ImageUrl = GetImageUrl(ThePresenter.GridValues[0, 1]);
            LB4.ImageUrl = GetImageUrl(ThePresenter.GridValues[1, 1]);
            LB5.ImageUrl = GetImageUrl(ThePresenter.GridValues[2, 1]);
            LB6.ImageUrl = GetImageUrl(ThePresenter.GridValues[0, 2]);
            LB7.ImageUrl = GetImageUrl(ThePresenter.GridValues[1, 2]);
            LB8.ImageUrl = GetImageUrl(ThePresenter.GridValues[2, 2]);

            LB0.Enabled = ThePresenter.IsReady && ThePresenter.GridValues[0, 0] == '-';
            LB1.Enabled = ThePresenter.IsReady && ThePresenter.GridValues[1, 0] == '-';
            LB2.Enabled = ThePresenter.IsReady && ThePresenter.GridValues[2, 0] == '-';
            LB3.Enabled = ThePresenter.IsReady && ThePresenter.GridValues[0, 1] == '-';
            LB4.Enabled = ThePresenter.IsReady && ThePresenter.GridValues[1, 1] == '-';
            LB5.Enabled = ThePresenter.IsReady && ThePresenter.GridValues[2, 1] == '-';
            LB6.Enabled = ThePresenter.IsReady && ThePresenter.GridValues[0, 2] == '-';
            LB7.Enabled = ThePresenter.IsReady && ThePresenter.GridValues[1, 2] == '-';
            LB8.Enabled = ThePresenter.IsReady && ThePresenter.GridValues[2, 2] == '-';

            NewLinkButton.Enabled = !ThePresenter.IsReady;
            QuitLinkButton.Enabled = !NewLinkButton.Enabled;

            BindGameGrid();
            BindStatGrid();
        }

        private string GetImageUrl(char token)
        {
            string url = "~/Images/u.png";
            switch (token)
            {
                case 'X':
                case 'x': url = "~/Images/x.png"; break;
                case 'O':
                case 'o': url = "~/Images/o.png"; break;
            }
            return url;
        }

        private void BindStatGrid()
        {
            StatisticsGridView.DataSource = ThePresenter.GamesStats;
            StatisticsGridView.DataBind();
        }

        private void BindGameGrid()
        {
            GamesGridView.DataSource = ThePresenter.PassedGames;
            GamesGridView.DataBind();
        }

        protected void NewLinkButton_Click(object sender, EventArgs e)
        {
            ThePresenter.NewGame();
        }

        protected void QuitLinkButton_Click(object sender, EventArgs e)
        {
            ThePresenter.QuitGame();
        }

        protected void LB0_Click(object sender, EventArgs e)
        {
            ThePresenter.MarkValue(0, 0);
        }

        protected void LB1_Click(object sender, EventArgs e)
        {
            ThePresenter.MarkValue(1, 0);
        }

        protected void LB2_Click(object sender, EventArgs e)
        {
            ThePresenter.MarkValue(2, 0);
        }

        protected void LB3_Click(object sender, EventArgs e)
        {
            ThePresenter.MarkValue(0, 1);
        }

        protected void LB4_Click(object sender, EventArgs e)
        {
            ThePresenter.MarkValue(1, 1);
        }

        protected void LB5_Click(object sender, EventArgs e)
        {
            ThePresenter.MarkValue(2, 1);
        }

        protected void LB6_Click(object sender, EventArgs e)
        {
            ThePresenter.MarkValue(0, 2);
        }

        protected void LB7_Click(object sender, EventArgs e)
        {
            ThePresenter.MarkValue(1, 2);
        }

        protected void LB8_Click(object sender, EventArgs e)
        {
            ThePresenter.MarkValue(2, 2);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //TimeLabel.Text = ThePresenter.GameDuration;
            if (ThePresenter.IsReady)
            {
                UpdatePanel1.Update();
            }
        }
    }
}