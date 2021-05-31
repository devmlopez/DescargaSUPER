namespace OdooMigraCorreos
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
            this.btnAbrirAccess = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txcontenido = new System.Windows.Forms.RichTextBox();
            this.btnCopiarTodo = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAbrirAccess
            // 
            this.btnAbrirAccess.Location = new System.Drawing.Point(24, 13);
            this.btnAbrirAccess.Name = "btnAbrirAccess";
            this.btnAbrirAccess.Size = new System.Drawing.Size(75, 23);
            this.btnAbrirAccess.TabIndex = 0;
            this.btnAbrirAccess.Text = "Abrir Access";
            this.btnAbrirAccess.UseVisualStyleBackColor = true;
            this.btnAbrirAccess.Click += new System.EventHandler(this.btnAbrirAccess_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(569, 20);
            this.textBox1.TabIndex = 1;
            // 
            // txcontenido
            // 
            this.txcontenido.Location = new System.Drawing.Point(24, 77);
            this.txcontenido.Name = "txcontenido";
            this.txcontenido.Size = new System.Drawing.Size(743, 380);
            this.txcontenido.TabIndex = 2;
            this.txcontenido.Text = "";
            // 
            // btnCopiarTodo
            // 
            this.btnCopiarTodo.Location = new System.Drawing.Point(106, 48);
            this.btnCopiarTodo.Name = "btnCopiarTodo";
            this.btnCopiarTodo.Size = new System.Drawing.Size(75, 23);
            this.btnCopiarTodo.TabIndex = 3;
            this.btnCopiarTodo.Text = "Copiar todo";
            this.btnCopiarTodo.UseVisualStyleBackColor = true;
            this.btnCopiarTodo.Click += new System.EventHandler(this.btnCopiarTodo_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(25, 48);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(75, 23);
            this.btnProcesar.TabIndex = 4;
            this.btnProcesar.Text = "Procesar Datos";
            this.btnProcesar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 469);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnCopiarTodo);
            this.Controls.Add(this.txcontenido);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAbrirAccess);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirAccess;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox txcontenido;
        private System.Windows.Forms.Button btnCopiarTodo;
        private System.Windows.Forms.Button btnProcesar;
    }
}

