
namespace OrderWinForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addOrder = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editOrder = new System.Windows.Forms.Button();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteOrder = new System.Windows.Forms.Button();
            this.importOrder = new System.Windows.Forms.Button();
            this.outputOrder = new System.Windows.Forms.Button();
            this.searchType = new System.Windows.Forms.ComboBox();
            this.filter = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // addOrder
            // 
            this.addOrder.Location = new System.Drawing.Point(13, 42);
            this.addOrder.Name = "addOrder";
            this.addOrder.Size = new System.Drawing.Size(75, 23);
            this.addOrder.TabIndex = 0;
            this.addOrder.Text = "新建订单";
            this.addOrder.UseVisualStyleBackColor = true;
            this.addOrder.Click += new System.EventHandler(this.addOrder_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNo,
            this.customerName,
            this.customerInfo,
            this.totalDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.orderBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(775, 367);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "customer";
            this.dataGridViewTextBoxColumn1.HeaderText = "customer";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // editOrder
            // 
            this.editOrder.Location = new System.Drawing.Point(94, 42);
            this.editOrder.Name = "editOrder";
            this.editOrder.Size = new System.Drawing.Size(75, 23);
            this.editOrder.TabIndex = 2;
            this.editOrder.Text = "修改订单";
            this.editOrder.UseVisualStyleBackColor = true;
            this.editOrder.Click += new System.EventHandler(this.editOrder_Click);
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(Order.Order);
            // 
            // orderNo
            // 
            this.orderNo.DataPropertyName = "orderNo";
            this.orderNo.HeaderText = "订单号";
            this.orderNo.MinimumWidth = 6;
            this.orderNo.Name = "orderNo";
            this.orderNo.ReadOnly = true;
            this.orderNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // customerName
            // 
            this.customerName.DataPropertyName = "customerName";
            this.customerName.HeaderText = "收货人";
            this.customerName.MinimumWidth = 6;
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            this.customerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // customerInfo
            // 
            this.customerInfo.DataPropertyName = "customerInfo";
            this.customerInfo.HeaderText = "联系方式";
            this.customerInfo.MinimumWidth = 6;
            this.customerInfo.Name = "customerInfo";
            this.customerInfo.ReadOnly = true;
            this.customerInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "总价";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // deleteOrder
            // 
            this.deleteOrder.Location = new System.Drawing.Point(175, 42);
            this.deleteOrder.Name = "deleteOrder";
            this.deleteOrder.Size = new System.Drawing.Size(75, 23);
            this.deleteOrder.TabIndex = 3;
            this.deleteOrder.Text = "删除订单";
            this.deleteOrder.UseVisualStyleBackColor = true;
            this.deleteOrder.Click += new System.EventHandler(this.deleteOrder_Click);
            // 
            // importOrder
            // 
            this.importOrder.Location = new System.Drawing.Point(256, 42);
            this.importOrder.Name = "importOrder";
            this.importOrder.Size = new System.Drawing.Size(75, 23);
            this.importOrder.TabIndex = 4;
            this.importOrder.Text = "导入订单";
            this.importOrder.UseVisualStyleBackColor = true;
            this.importOrder.Click += new System.EventHandler(this.importOrder_Click);
            // 
            // outputOrder
            // 
            this.outputOrder.Location = new System.Drawing.Point(337, 42);
            this.outputOrder.Name = "outputOrder";
            this.outputOrder.Size = new System.Drawing.Size(75, 23);
            this.outputOrder.TabIndex = 5;
            this.outputOrder.Text = "导出订单";
            this.outputOrder.UseVisualStyleBackColor = true;
            this.outputOrder.Click += new System.EventHandler(this.outputOrder_Click);
            // 
            // searchType
            // 
            this.searchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchType.FormattingEnabled = true;
            this.searchType.Items.AddRange(new object[] {
            "订单号",
            "收货人",
            "商品名",
            "总价"});
            this.searchType.Location = new System.Drawing.Point(13, 13);
            this.searchType.Name = "searchType";
            this.searchType.Size = new System.Drawing.Size(75, 23);
            this.searchType.TabIndex = 6;
            // 
            // filter
            // 
            this.filter.Location = new System.Drawing.Point(94, 13);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(236, 25);
            this.filter.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "查找订单";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(417, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "重置查找";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.searchType);
            this.Controls.Add(this.outputOrder);
            this.Controls.Add(this.importOrder);
            this.Controls.Add(this.deleteOrder);
            this.Controls.Add(this.editOrder);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.addOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "订单管理";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addOrder;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button editOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button deleteOrder;
        private System.Windows.Forms.Button importOrder;
        private System.Windows.Forms.Button outputOrder;
        private System.Windows.Forms.ComboBox searchType;
        private System.Windows.Forms.TextBox filter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

