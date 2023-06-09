﻿namespace BlazingTrails.Shared.Features.ManageTrails;
using FluentValidation;

public class TrailDto 
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Location { get; set; } = "";
    public int TimeInMinutes { get; set; }
    public int Length { get; set; }

    public List<RouteInstruction> Route { get; set; } = new();

    public class RouteInstruction
    {
        public int Stage { get; set; }
        public string Description { get; set; } = "";
    }
}



public class TrailValidator : AbstractValidator<TrailDto>
{
    public TrailValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Please enter a name");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Please enter a Description");
        
        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("Please enter a Location");
        
        RuleFor(x => x.Length)
            .GreaterThan(0)
            .WithMessage("Please enter a Length");
        
        RuleFor(x => x.Route)
            .NotEmpty()
            .WithMessage("Please enter a route instruction");

        RuleForEach(x => x.Route).SetValidator(new RouteInstructionValidator());
    }
}

public class RouteInstructionValidator : AbstractValidator<TrailDto.RouteInstruction>
{
    public RouteInstructionValidator()
    {
        
        RuleFor(x => x.Stage)
            .NotEmpty()
            .WithMessage("Please enter a Stage");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Please enter a Description");
        
    }
}