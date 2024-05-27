namespace DS.DriveShare.Resources;

public class SaveParkingResource
{
    public int ParkingId { get; set; }
    public string Description { get; set; }
    public float Stars { get; set; }
    public string Phone { get; set; }
    public int MaxCapacity { get; set; }
    public int AvailableCapacity { get; set; }
    public int LocationId { get; set; }
    public int ScheduleId { get; set; }
    public int GuestId { get; set; }
    public DateTime DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
}