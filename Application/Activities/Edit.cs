using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities;

public class Edit
{
    public class Command : IRequest{
        public Activity Activity { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public Handler(DataContext  dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await _dataContext.Activities.FindAsync(request.Activity.Id);

            // activity.Title = request.Activity.Title ?? activity.Title;
            _mapper.Map(request.Activity, activity);

            await _dataContext.SaveChangesAsync();
        }
    }
}