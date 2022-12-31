using System;


namespace Rocket_Elevators_Customer_Portal
{

  public class Elevator
{
    public long Id { get; set; }
    public string SerialNumber { get; set; }
    public string Model { get; set; }
    public string Status { get; set; }
    public DateTime DateCommissioning { get; set; }
    public DateTime DateLastInspection { get; set; }
    public string CertificateInspection { get; set; }
    public string Information { get; set; }
    public string Notes { get; set; }
    public string BuildingType { get; set; }
    public long ColumnId { get; set; }
}

public class Column
{
    public long Id { get; set; }
    public int NumberFloorsServed { get; set; }
    public string Status { get; set; }
    public string Information { get; set; }
    public string Notes { get; set; }
    public string BuildingType { get; set; }
    public long BatteryId { get; set; }
    public List<Elevator> Elevators { get; set; }
}

public class Battery
{
        public long Id { get; set; }
        public string TypeBuilding { get; set; }
        public DateTime DateCommissioning { get; set; }
        public DateTime DateLastInspection { get; set; }
        public string CertificateOperations { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public long EmployeeId { get; set; }
        public long BuildingId { get; set; }
        public List<Column> Columns { get; set; }
}

public class Building
    {
    public long Id { get; set; }
    public string BuildingAddress { get; set; }
    public string AdminFullName { get; set; }
    public string AdminEmail { get; set; }
    public string AdminPhoneNumber { get; set; }
    public string TechnicalContactFullName { get; set; }
    public string TechnicalContactEmail { get; set; }
    public string TechnicalContactPhoneNumber { get; set; }
    public long CustomerId { get; set; }

    public List<Battery> Batteries { get; set; }
    }

}






