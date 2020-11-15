using DataLayer;
using DataLayer.Entities;
using DevelopmentSystemTest.ThreadClasses.DateChanger;
using System;
using System.Windows.Forms;

namespace DevelopmentSystemTest.Forms.ParkingCars
{
    public partial class ParkingCarsForm : Form
    {
        private readonly Parking parking;
        private readonly IDateChanger dateChanger;

        public ParkingCarsForm(Parking parking, IDateChanger dateChanger)
        {
            InitializeComponent();

            this.parking = parking;
            this.dateChanger = dateChanger;

            var numbeColumn = CreateGridTextBoxCell("Номер", 180);
            var makeColumn = CreateGridTextBoxCell("Марка", 180);
            var modelColumn = CreateGridTextBoxCell("Модель", 180);
            var colorColumn = CreateGridTextBoxCell("Цвет", 180);

            dataGridView1.Columns.Add(numbeColumn);
            dataGridView1.Columns.Add(makeColumn);
            dataGridView1.Columns.Add(modelColumn);
            dataGridView1.Columns.Add(colorColumn);

            dataGridView1.AllowUserToAddRows = false;

            dateChanger.DayChangeNotify += UpdateDataGrid;

            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(UpdateDataGrid));
                return;
            }

            dataGridView1.Rows.Clear();

            foreach (var car in parking.Cars)
            {
                dataGridView1.Rows.Add(car.Number, car.Make.Title, car.Model.Title, car.Color.GetDescription());
            }
        }

        private void ParkingCarsForm_Closing(object sender, EventArgs e)
        {
            dateChanger.DayChangeNotify -= UpdateDataGrid;
            Program.container.Release(this);
        }

        private DataGridViewColumn CreateGridTextBoxCell(String headerText, int columnWidth, bool readOnly = true)
            => new DataGridViewColumn()
            {
                HeaderText = headerText,
                Width = columnWidth,
                ReadOnly = readOnly,
                CellTemplate = new DataGridViewTextBoxCell()
            };
    }
}
