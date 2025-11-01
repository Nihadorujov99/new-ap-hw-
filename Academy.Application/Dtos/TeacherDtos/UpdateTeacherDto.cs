namespace Academy.Application.Dtos.TeacherDtos;

public class UpdateTeacherDto
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}

