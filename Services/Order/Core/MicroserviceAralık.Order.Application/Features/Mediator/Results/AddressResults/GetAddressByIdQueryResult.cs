namespace MicroserviceAralık.Order.Application.Features.Mediator.Results.AddressResults;
public class GetAddressByIdQueryResult
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public string Description { get; set; }
}
