﻿namespace Hipages.Tradies.Application.Features.Jobs.Queries.GetJobList;

public class GetJobListViewModel
{
    public int Id { get; set; }
    public JobStatus Status { get; set; }
    public string SuburbName { get; set; }
    public string Postcode { get; set; }
    public string CategoryName { get; set; }
    public string ContactName { get; set; }
    public string ContactPhone { get; set; }
    public string ContactEmail { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}