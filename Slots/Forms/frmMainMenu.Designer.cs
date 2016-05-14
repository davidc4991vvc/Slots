namespace Slots.Forms
{
    partial class frmMainMenu
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
            this.lb_TitleBar = new System.Windows.Forms.Label();
            this.btn_AppleSlots = new System.Windows.Forms.Button();
            this.btn_OrangeSlots = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_TitleBar
            // 
            this.lb_TitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TitleBar.Location = new System.Drawing.Point(76, 9);
            this.lb_TitleBar.Name = "lb_TitleBar";
            this.lb_TitleBar.Size = new System.Drawing.Size(638, 123);
            this.lb_TitleBar.TabIndex = 0;
            this.lb_TitleBar.Text = "Hippo Games Slots";
            // 
            // btn_AppleSlots
            // 
            this.btn_AppleSlots.Location = new System.Drawing.Point(89, 236);
            this.btn_AppleSlots.Name = "btn_AppleSlots";
            this.btn_AppleSlots.Size = new System.Drawing.Size(242, 81);
            this.btn_AppleSlots.TabIndex = 1;
            this.btn_AppleSlots.Text = "AppleSlots";
            this.btn_AppleSlots.UseVisualStyleBackColor = true;
            this.btn_AppleSlots.Click += new System.EventHandler(this.btn_AppleSlots_Click);
            // 
            // btn_OrangeSlots
            // 
            this.btn_OrangeSlots.Location = new System.Drawing.Point(89, 323);
            this.btn_OrangeSlots.Name = "btn_OrangeSlots";
            this.btn_OrangeSlots.Size = new System.Drawing.Size(242, 81);
            this.btn_OrangeSlots.TabIndex = 2;
            this.btn_OrangeSlots.Text = "OrangeSlots";
            this.btn_OrangeSlots.UseVisualStyleBackColor = true;
            this.btn_OrangeSlots.Click += new System.EventHandler(this.btn_OrangeSlots_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(482, 68);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose Your Game";
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(765, 522);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_OrangeSlots);
            this.Controls.Add(this.btn_AppleSlots);
            this.Controls.Add(this.lb_TitleBar);
            this.Name = "frmMainMenu";
            this.Text = "frmMainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_TitleBar;
        private System.Windows.Forms.Button btn_AppleSlots;
        private System.Windows.Forms.Button btn_OrangeSlots;
        private System.Windows.Forms.Label label1;
    }
}