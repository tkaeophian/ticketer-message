using Ardalis.Result;
using Ardalis.SharedKernel;
using Ticketer.Message.Core.ContributorAggregate;
using Ticketer.Message.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ticketer.Message.UnitTests.Core.Services;

public class DeleteContributorService_DeleteContributor
{
    private readonly ILogger<DeleteContributorService> _logger = Substitute.For<ILogger<DeleteContributorService>>();
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly IRepository<Contributor> _repository = Substitute.For<IRepository<Contributor>>();

    private readonly DeleteContributorService _service;

    public DeleteContributorService_DeleteContributor()
    {
        _service = new DeleteContributorService(_repository, _mediator, _logger);
    }

    [Fact]
    public async Task ReturnsNotFoundGivenCantFindContributor()
    {
        var result = await _service.DeleteContributor(0);

        Assert.Equal(ResultStatus.NotFound, result.Status);
    }
}
