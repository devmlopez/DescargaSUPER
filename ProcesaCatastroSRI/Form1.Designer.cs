namespace ProcesaCatastroSRI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtrutaarchivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblcontadorlineasprocesadas = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txtrutaarchivo
            // 
            this.txtrutaarchivo.Location = new System.Drawing.Point(103, 33);
            this.txtrutaarchivo.Name = "txtrutaarchivo";
            this.txtrutaarchivo.Size = new System.Drawing.Size(687, 20);
            this.txtrutaarchivo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta Archivo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre Archivo:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(103, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(687, 20);
            this.textBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Abrir Catastro";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Procesar Catastro";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Registros Procesados:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblcontadorlineasprocesadas
            // 
            this.lblcontadorlineasprocesadas.AutoSize = true;
            this.lblcontadorlineasprocesadas.Location = new System.Drawing.Point(138, 139);
            this.lblcontadorlineasprocesadas.Name = "lblcontadorlineasprocesadas";
            this.lblcontadorlineasprocesadas.Size = new System.Drawing.Size(42, 13);
            this.lblcontadorlineasprocesadas.TabIndex = 7;
            this.lblcontadorlineasprocesadas.Text = "0/1000";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 261);
            this.Controls.Add(this.lblcontadorlineasprocesadas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtrutaarchivo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtrutaarchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblcontadorlineasprocesadas;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

