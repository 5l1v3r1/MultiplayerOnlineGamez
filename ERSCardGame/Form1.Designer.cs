namespace ERSCardGame
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.logtext = new System.Windows.Forms.Label();
			this.namegroupbox = new System.Windows.Forms.GroupBox();
			this.namebox = new System.Windows.Forms.TextBox();
			this.sendname = new System.Windows.Forms.Button();
			this.slapbutton = new System.Windows.Forms.Button();
			this.card1 = new System.Windows.Forms.Panel();
			this.card2 = new System.Windows.Forms.Panel();
			this.card3 = new System.Windows.Forms.Panel();
			this.exittester = new System.Windows.Forms.Timer(this.components);
			this.namegroupbox.SuspendLayout();
			this.SuspendLayout();
			// 
			// logtext
			// 
			this.logtext.AutoSize = true;
			this.logtext.Location = new System.Drawing.Point(12, 9);
			this.logtext.Name = "logtext";
			this.logtext.Size = new System.Drawing.Size(10, 13);
			this.logtext.TabIndex = 0;
			this.logtext.Text = " ";
			// 
			// namegroupbox
			// 
			this.namegroupbox.Controls.Add(this.namebox);
			this.namegroupbox.Controls.Add(this.sendname);
			this.namegroupbox.Location = new System.Drawing.Point(557, 363);
			this.namegroupbox.Name = "namegroupbox";
			this.namegroupbox.Size = new System.Drawing.Size(334, 75);
			this.namegroupbox.TabIndex = 1;
			this.namegroupbox.TabStop = false;
			this.namegroupbox.Text = "Set Name";
			// 
			// namebox
			// 
			this.namebox.Location = new System.Drawing.Point(6, 33);
			this.namebox.MaxLength = 25;
			this.namebox.Name = "namebox";
			this.namebox.Size = new System.Drawing.Size(117, 20);
			this.namebox.TabIndex = 1;
			// 
			// sendname
			// 
			this.sendname.Location = new System.Drawing.Point(129, 31);
			this.sendname.Name = "sendname";
			this.sendname.Size = new System.Drawing.Size(75, 23);
			this.sendname.TabIndex = 0;
			this.sendname.Text = "Connect";
			this.sendname.UseVisualStyleBackColor = true;
			this.sendname.Click += new System.EventHandler(this.Sendname_Click);
			// 
			// slapbutton
			// 
			this.slapbutton.Enabled = false;
			this.slapbutton.Location = new System.Drawing.Point(239, 379);
			this.slapbutton.Name = "slapbutton";
			this.slapbutton.Size = new System.Drawing.Size(295, 43);
			this.slapbutton.TabIndex = 2;
			this.slapbutton.Text = "Slap";
			this.slapbutton.UseVisualStyleBackColor = true;
			this.slapbutton.Click += new System.EventHandler(this.Slapbutton_Click);
			// 
			// card1
			// 
			this.card1.Location = new System.Drawing.Point(263, 154);
			this.card1.Name = "card1";
			this.card1.Size = new System.Drawing.Size(84, 115);
			this.card1.TabIndex = 3;
			// 
			// card2
			// 
			this.card2.Location = new System.Drawing.Point(353, 154);
			this.card2.Name = "card2";
			this.card2.Size = new System.Drawing.Size(84, 115);
			this.card2.TabIndex = 4;
			// 
			// card3
			// 
			this.card3.Location = new System.Drawing.Point(443, 154);
			this.card3.Name = "card3";
			this.card3.Size = new System.Drawing.Size(84, 115);
			this.card3.TabIndex = 4;
			// 
			// exittester
			// 
			this.exittester.Enabled = true;
			this.exittester.Tick += new System.EventHandler(this.Exittester_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.card2);
			this.Controls.Add(this.card3);
			this.Controls.Add(this.card1);
			this.Controls.Add(this.slapbutton);
			this.Controls.Add(this.namegroupbox);
			this.Controls.Add(this.logtext);
			this.Name = "Form1";
			this.Text = "ERS Card Game";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.namegroupbox.ResumeLayout(false);
			this.namegroupbox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label logtext;
		private System.Windows.Forms.GroupBox namegroupbox;
		private System.Windows.Forms.Button sendname;
		private System.Windows.Forms.TextBox namebox;
		private System.Windows.Forms.Button slapbutton;
		private System.Windows.Forms.Panel card1;
		private System.Windows.Forms.Panel card2;
		private System.Windows.Forms.Panel card3;
		private System.Windows.Forms.Timer exittester;
	}
}

