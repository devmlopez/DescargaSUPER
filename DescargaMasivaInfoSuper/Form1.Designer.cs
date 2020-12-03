namespace DescargaMasiva 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtparticiones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInicial = new System.Windows.Forms.TextBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnombrebasedatos = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtconstrasenia = new System.Windows.Forms.TextBox();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(30, 92);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 26;
            this.btnCerrar.Text = "Cerrar todo";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Particiones";
            // 
            // txtparticiones
            // 
            this.txtparticiones.Location = new System.Drawing.Point(222, 109);
            this.txtparticiones.Name = "txtparticiones";
            this.txtparticiones.Size = new System.Drawing.Size(100, 20);
            this.txtparticiones.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Expediente final";
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new System.Drawing.Point(222, 83);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(100, 20);
            this.txtFinal.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Expediente inicial";
            // 
            // txtInicial
            // 
            this.txtInicial.Location = new System.Drawing.Point(222, 60);
            this.txtInicial.Name = "txtInicial";
            this.txtInicial.Size = new System.Drawing.Size(100, 20);
            this.txtInicial.TabIndex = 20;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(30, 63);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 19;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nombre BD";
            // 
            // txtnombrebasedatos
            // 
            this.txtnombrebasedatos.Location = new System.Drawing.Point(81, 9);
            this.txtnombrebasedatos.Name = "txtnombrebasedatos";
            this.txtnombrebasedatos.Size = new System.Drawing.Size(367, 20);
            this.txtnombrebasedatos.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnIniciar);
            this.panel1.Controls.Add(this.txtnombrebasedatos);
            this.panel1.Controls.Add(this.txtInicial);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtFinal);
            this.panel1.Controls.Add(this.txtparticiones);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 319);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 212);
            this.panel1.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(78, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(329, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Escribir el nombre de la base de datos para la recolección de la data";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressPanel1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtconstrasenia);
            this.panel2.Controls.Add(this.txtusuario);
            this.panel2.Controls.Add(this.btnEntrar);
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 309);
            this.panel2.TabIndex = 30;
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.Caption = "Espere un momento por favor";
            this.progressPanel1.Description = "Iniciando Sesión ...";
            this.progressPanel1.Location = new System.Drawing.Point(234, 206);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(307, 66);
            this.progressPanel1.TabIndex = 33;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(154, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Contraseña:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Usuario:";
            // 
            // txtconstrasenia
            // 
            this.txtconstrasenia.Location = new System.Drawing.Point(238, 150);
            this.txtconstrasenia.Name = "txtconstrasenia";
            this.txtconstrasenia.PasswordChar = '*';
            this.txtconstrasenia.Size = new System.Drawing.Size(218, 20);
            this.txtconstrasenia.TabIndex = 29;
            this.txtconstrasenia.UseSystemPasswordChar = true;
            // 
            // txtusuario
            // 
            this.txtusuario.Location = new System.Drawing.Point(238, 124);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(218, 20);
            this.txtusuario.TabIndex = 28;
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(238, 177);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(199, 23);
            this.btnEntrar.TabIndex = 0;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
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
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(749, 556);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Intuito S.A.";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtparticiones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInicial;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnombrebasedatos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtconstrasenia;
        private System.Windows.Forms.TextBox txtusuario;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private System.Windows.Forms.Label label7;
    }
}

