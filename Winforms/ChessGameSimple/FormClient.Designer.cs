﻿namespace ChessGameSimple
{
    partial class FormClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSendMessage = new Button();
            lstMessages = new ListBox();
            panel1 = new Panel();
            tbMessage = new TextBox();
            pnlBoard = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSendMessage
            // 
            btnSendMessage.Location = new Point(167, 418);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new Size(75, 23);
            btnSendMessage.TabIndex = 0;
            btnSendMessage.Text = "Send";
            btnSendMessage.UseVisualStyleBackColor = true;
            btnSendMessage.Click += btnSendMessage_Click;
            // 
            // lstMessages
            // 
            lstMessages.FormattingEnabled = true;
            lstMessages.ItemHeight = 15;
            lstMessages.Location = new Point(3, 3);
            lstMessages.Name = "lstMessages";
            lstMessages.Size = new Size(239, 409);
            lstMessages.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(tbMessage);
            panel1.Controls.Add(btnSendMessage);
            panel1.Controls.Add(lstMessages);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(458, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(245, 446);
            panel1.TabIndex = 2;
            // 
            // tbMessage
            // 
            tbMessage.Location = new Point(3, 418);
            tbMessage.Name = "tbMessage";
            tbMessage.PlaceholderText = "message...";
            tbMessage.Size = new Size(158, 23);
            tbMessage.TabIndex = 2;
            // 
            // pnlBoard
            // 
            pnlBoard.Location = new Point(12, 5);
            pnlBoard.Name = "pnlBoard";
            pnlBoard.Size = new Size(443, 438);
            pnlBoard.TabIndex = 3;
            // 
            // FormClient
            // 
            AcceptButton = btnSendMessage;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(703, 446);
            Controls.Add(pnlBoard);
            Controls.Add(panel1);
            KeyPreview = true;
            Name = "FormClient";
            ShowIcon = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Chess Client";
            KeyDown += FormClient_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSendMessage;
        private ListBox lstMessages;
        private Panel panel1;
        private TextBox tbMessage;
        private Panel pnlBoard;
    }
}