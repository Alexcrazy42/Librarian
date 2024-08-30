using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/ed-book-people-rents")]
public class EdBookPeopleRentController
{
    private readonly IMapper mapper;

	public EdBookPeopleRentController(IMapper mapper)
	{
		this.mapper = mapper;
	}

	public async Task GiveEdBookToStudentAsync()
	{
		throw new NotImplementedException();
	}

    public async Task GiveEdBookToEmployeeAsync()
    {
        throw new NotImplementedException();
    }
}
