namespace EncrypterDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.BackColor = Color.MintCream;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Cursor = Cursors.Hand;
            textBox1.ForeColor = Color.Silver;
            textBox1.Name = "textBox1";
            textBox1.Click += OnTextboxSecretKeyActivate;
            textBox1.Leave += OnMouseLeaveTextboxSecretKey;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.MintCream;
            label1.Name = "label1";
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.BackColor = Color.MediumSeaGreen;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = SystemColors.ControlText;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += OnEncryptActivate;
            button1.MouseEnter += OnMouseEnterToEncryptButton;
            button1.MouseLeave += OnMouseLeaveToEncryptButton;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.BackColor = Color.RosyBrown;
            button2.Cursor = Cursors.Hand;
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = false;
            button2.Click += OnDecryptActivate;
            button2.MouseEnter += OnMouseEnterDecryptButton;
            button2.MouseLeave += OnMouseLeaveDecryptButton;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = Color.MintCream;
            label2.Name = "label2";
            // 
            // button3
            // 
            resources.ApplyResources(button3, "button3");
            button3.BackColor = Color.DarkCyan;
            button3.ForeColor = SystemColors.ControlText;
            button3.Name = "button3";
            button3.UseVisualStyleBackColor = false;
            button3.Click += OnClearSecretKeyEntryField;
            button3.MouseEnter += OnMouseEnterToClearSecretKeyTextbox;
            button3.MouseLeave += OnMouseLeaveToClearSecretKeyTextbox;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "Form1";
            Opacity = 0.99D;
            Click += OnMouseLeaveTextboxSecretKey;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
        private Button button3;
    }
}