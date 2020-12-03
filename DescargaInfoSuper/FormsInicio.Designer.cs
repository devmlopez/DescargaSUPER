namespace DescargaInfoIntuito
{
    partial class FormsInicio
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInicial = new System.Windows.Forms.TextBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtparticiones = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Expediente final";
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new System.Drawing.Point(204, 42);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(100, 20);
            this.txtFinal.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Expediente inicial";
            // 
            // txtInicial
            // 
            this.txtInicial.Location = new System.Drawing.Point(204, 19);
            this.txtInicial.Name = "txtInicial";
            this.txtInicial.Size = new System.Drawing.Size(100, 20);
            this.txtInicial.TabIndex = 11;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(12, 22);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 10;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Particiones";
            // 
            // txtparticiones
            // 
            this.txtparticiones.Location = new System.Drawing.Point(204, 68);
            this.txtparticiones.Name = "txtparticiones";
            this.txtparticiones.Size = new System.Drawing.Size(100, 20);
            this.txtparticiones.TabIndex = 16;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(12, 51);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.Text = "Cerrar todo";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormsInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 144);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtparticiones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInicial);
            this.Controls.Add(this.btnIniciar);
            this.Name = "FormsInicio";
            this.Text = "FormsInicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInicial;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtparticiones;
        private System.Windows.Forms.Button btnCerrar;
    }
}