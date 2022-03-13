namespace ASE_Applcation
{
    partial class Window
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
            this.ScriptBox = new System.Windows.Forms.TextBox();
            this.DrawingArea = new System.Windows.Forms.PictureBox();
            this.CommandLine = new System.Windows.Forms.TextBox();
            this.ExecuteCommand = new System.Windows.Forms.Button();
            this.ExecuteScript = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // ScriptBox
            // 
            this.ScriptBox.AcceptsTab = true;
            this.ScriptBox.Location = new System.Drawing.Point(14, 15);
            this.ScriptBox.Multiline = true;
            this.ScriptBox.Name = "ScriptBox";
            this.ScriptBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ScriptBox.Size = new System.Drawing.Size(400, 296);
            this.ScriptBox.TabIndex = 1;
            // 
            // DrawingArea
            // 
            this.DrawingArea.Location = new System.Drawing.Point(424, 15);
            this.DrawingArea.Name = "DrawingArea";
            this.DrawingArea.Size = new System.Drawing.Size(550, 296);
            this.DrawingArea.TabIndex = 0;
            this.DrawingArea.TabStop = false;
            // 
            // CommandLine
            // 
            this.CommandLine.Location = new System.Drawing.Point(14, 383);
            this.CommandLine.Name = "CommandLine";
            this.CommandLine.Size = new System.Drawing.Size(319, 20);
            this.CommandLine.TabIndex = 4;

            // 
            // ExecuteCommand
            // 
            this.ExecuteCommand.Location = new System.Drawing.Point(341, 383);
            this.ExecuteCommand.Name = "ExecuteCommand";
            this.ExecuteCommand.Size = new System.Drawing.Size(60, 20);
            this.ExecuteCommand.TabIndex = 3;
            this.ExecuteCommand.Text = "Execute";
            this.ExecuteCommand.UseVisualStyleBackColor = true;
            // 
            // ExecuteScript
            // 
            this.ExecuteScript.Location = new System.Drawing.Point(14, 323);
            this.ExecuteScript.Name = "ExecuteScript";
            this.ExecuteScript.Size = new System.Drawing.Size(167, 51);
            this.ExecuteScript.TabIndex = 2;
            this.ExecuteScript.Text = "Execute Script";
            this.ExecuteScript.UseVisualStyleBackColor = true;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 503);
            this.Controls.Add(this.CommandLine);
            this.Controls.Add(this.ExecuteCommand);
            this.Controls.Add(this.ExecuteScript);
            this.Controls.Add(this.ScriptBox);
            this.Controls.Add(this.DrawingArea);
            this.Name = "Window";
            this.Text = "Program";
            ((System.ComponentModel.ISupportInitialize)(this.DrawingArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ScriptBox;
        private System.Windows.Forms.PictureBox DrawingArea;
        private System.Windows.Forms.TextBox CommandLine;
        private System.Windows.Forms.Button ExecuteCommand;
        private System.Windows.Forms.Button ExecuteScript;
    }
}

