namespace SistemaArbolArchivos
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
            treeViewArchivos = new TreeView();
            groupBox1 = new GroupBox();
            label5 = new Label();
            lblRuta = new Label();
            listBoxResultados = new ListBox();
            btnConteo = new Button();
            btnPostorden = new Button();
            label3 = new Label();
            btnPreorden = new Button();
            btnAgregar = new Button();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            rbArchivo = new RadioButton();
            rbCarpeta = new RadioButton();
            txtNodoHijo = new TextBox();
            txtNodoPadre = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // treeViewArchivos
            // 
            treeViewArchivos.Dock = DockStyle.Left;
            treeViewArchivos.Location = new Point(0, 0);
            treeViewArchivos.Name = "treeViewArchivos";
            treeViewArchivos.Size = new Size(280, 460);
            treeViewArchivos.TabIndex = 0;
            treeViewArchivos.AfterSelect += treeViewArchivos_AfterSelect;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblRuta);
            groupBox1.Controls.Add(listBoxResultados);
            groupBox1.Controls.Add(btnConteo);
            groupBox1.Controls.Add(btnPostorden);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnPreorden);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(rbArchivo);
            groupBox1.Controls.Add(rbCarpeta);
            groupBox1.Controls.Add(txtNodoHijo);
            groupBox1.Controls.Add(txtNodoPadre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(286, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(606, 460);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Agregar Nodo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(8, 290);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 15;
            label5.Text = "Ruta: ";
            // 
            // lblRuta
            // 
            lblRuta.AutoSize = true;
            lblRuta.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRuta.Location = new Point(57, 290);
            lblRuta.Name = "lblRuta";
            lblRuta.Size = new Size(21, 17);
            lblRuta.TabIndex = 14;
            lblRuta.Text = "—";
            lblRuta.Click += lblRuta_Click;
            // 
            // listBoxResultados
            // 
            listBoxResultados.Dock = DockStyle.Bottom;
            listBoxResultados.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxResultados.FormattingEnabled = true;
            listBoxResultados.ItemHeight = 20;
            listBoxResultados.Location = new Point(3, 313);
            listBoxResultados.Name = "listBoxResultados";
            listBoxResultados.Size = new Size(600, 144);
            listBoxResultados.TabIndex = 13;
            // 
            // btnConteo
            // 
            btnConteo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConteo.Location = new Point(200, 228);
            btnConteo.Name = "btnConteo";
            btnConteo.Size = new Size(91, 33);
            btnConteo.TabIndex = 12;
            btnConteo.Text = "Conteo";
            btnConteo.UseVisualStyleBackColor = true;
            btnConteo.Click += btnConteo_Click;
            // 
            // btnPostorden
            // 
            btnPostorden.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPostorden.Location = new Point(103, 228);
            btnPostorden.Name = "btnPostorden";
            btnPostorden.Size = new Size(91, 33);
            btnPostorden.TabIndex = 11;
            btnPostorden.Text = "Postorden";
            btnPostorden.UseVisualStyleBackColor = true;
            btnPostorden.Click += btnPostorden_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(8, 204);
            label3.Name = "label3";
            label3.Size = new Size(78, 21);
            label3.TabIndex = 10;
            label3.Text = "Acciones";
            // 
            // btnPreorden
            // 
            btnPreorden.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPreorden.Location = new Point(6, 228);
            btnPreorden.Name = "btnPreorden";
            btnPreorden.Size = new Size(91, 33);
            btnPreorden.TabIndex = 9;
            btnPreorden.Text = "Preorden";
            btnPreorden.UseVisualStyleBackColor = true;
            btnPreorden.Click += btnPreorden_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(467, 180);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(127, 33);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(291, 40);
            txtBuscar.Multiline = true;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(234, 33);
            txtBuscar.TabIndex = 7;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscar.Location = new Point(523, 40);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(71, 33);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // rbArchivo
            // 
            rbArchivo.AutoSize = true;
            rbArchivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbArchivo.Location = new Point(94, 44);
            rbArchivo.Name = "rbArchivo";
            rbArchivo.Size = new Size(81, 25);
            rbArchivo.TabIndex = 5;
            rbArchivo.Text = "Archivo";
            rbArchivo.UseVisualStyleBackColor = true;
            // 
            // rbCarpeta
            // 
            rbCarpeta.AutoSize = true;
            rbCarpeta.Checked = true;
            rbCarpeta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbCarpeta.Location = new Point(6, 44);
            rbCarpeta.Name = "rbCarpeta";
            rbCarpeta.Size = new Size(82, 25);
            rbCarpeta.TabIndex = 4;
            rbCarpeta.TabStop = true;
            rbCarpeta.Text = "Carpeta";
            rbCarpeta.UseVisualStyleBackColor = true;
            // 
            // txtNodoHijo
            // 
            txtNodoHijo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNodoHijo.Location = new Point(123, 135);
            txtNodoHijo.Multiline = true;
            txtNodoHijo.Name = "txtNodoHijo";
            txtNodoHijo.Size = new Size(471, 28);
            txtNodoHijo.TabIndex = 3;
            // 
            // txtNodoPadre
            // 
            txtNodoPadre.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNodoPadre.Location = new Point(137, 93);
            txtNodoPadre.Multiline = true;
            txtNodoPadre.Name = "txtNodoPadre";
            txtNodoPadre.Size = new Size(457, 28);
            txtNodoPadre.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 139);
            label2.Name = "label2";
            label2.Size = new Size(111, 21);
            label2.TabIndex = 1;
            label2.Text = "Nombre hijo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 97);
            label1.Name = "label1";
            label1.Size = new Size(125, 21);
            label1.TabIndex = 0;
            label1.Text = "Nombre padre:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 460);
            Controls.Add(groupBox1);
            Controls.Add(treeViewArchivos);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeViewArchivos;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtNodoHijo;
        private TextBox txtNodoPadre;
        private Label label2;
        private RadioButton rbArchivo;
        private RadioButton rbCarpeta;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Button btnAgregar;
        private ListBox listBoxResultados;
        private Button btnConteo;
        private Button btnPostorden;
        private Label label3;
        private Button btnPreorden;
        private Label label5;
        private Label lblRuta;
    }
}
