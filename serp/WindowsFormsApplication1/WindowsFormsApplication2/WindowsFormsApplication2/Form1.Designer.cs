namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonEnt = new System.Windows.Forms.Button();
            this.numericUpDownSelectLvl = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonInd = new System.Windows.Forms.Button();
            this.buttonMul = new System.Windows.Forms.Button();
            this.checkBoxModo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectLvl)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEnt
            // 
            this.buttonEnt.Location = new System.Drawing.Point(134, 12);
            this.buttonEnt.Name = "buttonEnt";
            this.buttonEnt.Size = new System.Drawing.Size(75, 23);
            this.buttonEnt.TabIndex = 1;
            this.buttonEnt.Text = "Entrenamiento";
            this.buttonEnt.UseVisualStyleBackColor = true;
            this.buttonEnt.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDownSelectLvl
            // 
            this.numericUpDownSelectLvl.Location = new System.Drawing.Point(134, 50);
            this.numericUpDownSelectLvl.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownSelectLvl.Name = "numericUpDownSelectLvl";
            this.numericUpDownSelectLvl.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownSelectLvl.TabIndex = 2;
            // 
            // buttonInd
            // 
            this.buttonInd.Location = new System.Drawing.Point(12, 12);
            this.buttonInd.Name = "buttonInd";
            this.buttonInd.Size = new System.Drawing.Size(75, 23);
            this.buttonInd.TabIndex = 4;
            this.buttonInd.Text = "Individual";
            this.buttonInd.UseVisualStyleBackColor = true;
            this.buttonInd.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonMul
            // 
            this.buttonMul.Location = new System.Drawing.Point(233, 12);
            this.buttonMul.Name = "buttonMul";
            this.buttonMul.Size = new System.Drawing.Size(75, 23);
            this.buttonMul.TabIndex = 5;
            this.buttonMul.Text = "Multi";
            this.buttonMul.UseVisualStyleBackColor = true;
            this.buttonMul.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBoxModo
            // 
            this.checkBoxModo.AutoSize = true;
            this.checkBoxModo.Location = new System.Drawing.Point(242, 50);
            this.checkBoxModo.Name = "checkBoxModo";
            this.checkBoxModo.Size = new System.Drawing.Size(47, 17);
            this.checkBoxModo.TabIndex = 6;
            this.checkBoxModo.Text = "A/B\'";
            this.checkBoxModo.UseVisualStyleBackColor = true;
            this.checkBoxModo.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 98);
            this.Controls.Add(this.checkBoxModo);
            this.Controls.Add(this.buttonMul);
            this.Controls.Add(this.buttonInd);
            this.Controls.Add(this.numericUpDownSelectLvl);
            this.Controls.Add(this.buttonEnt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectLvl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEnt;
        private System.Windows.Forms.NumericUpDown numericUpDownSelectLvl;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonInd;
        private System.Windows.Forms.Button buttonMul;
        private System.Windows.Forms.CheckBox checkBoxModo;
    }
}

