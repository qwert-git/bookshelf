using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using Bookshelf.Domain;
using Bookshelf.Infrastructure.Mapping;
using Bookshelf.Infrastructure.Persistence.Entities;
using FluentAssertions;
using Xunit;

namespace Bookshelf.Infrastructure.Tests.Mappings;

public class BookAdvertEntityProfileTests
{
    private readonly MapperConfiguration _config;
    private readonly IMapper _mapper;

    public BookAdvertEntityProfileTests()
    {
        _config = new MapperConfiguration(cfg => cfg.AddProfile<BookAdvertEntityProfile>());
        _mapper = _config.CreateMapper();
    }

    [Fact]
    public void AddConfiguration_AssertConfiguration_Should_Not_ThrowException()
    {
        _config.AssertConfigurationIsValid();
    }

    [Theory, AutoData]
    internal void MapToBookAdvert_Id_Should_BeEquelToSource(BookAdvertEntity entity)
    {
        // Act
        var bookAdvert = _mapper.Map<BookAdvert>(entity);

        // Assert
        bookAdvert.Id.Should()
            .NotBe(default)
            .And
            .Be(entity.Id);
    }

    [Theory, AutoData]
    internal void MapToBookAdvert_Description_Should_BeEquelToSource(BookAdvertEntity entity)
    {
        // Act
        var bookAdvert = _mapper.Map<BookAdvert>(entity);

        // Assert
        bookAdvert.Description.Should()
            .NotBeNull()
            .And
            .Be(entity.Description);
    }

    [Theory, AutoData]
    internal void MapToBookAdvert_Title_Should_BeEquelToSource(BookAdvertEntity entity)
    {
        // Act
        var bookAdvert = _mapper.Map<BookAdvert>(entity);

        // Assert
        bookAdvert.Title.Should()
            .NotBeNull()
            .And
            .Be(entity.Title);
    }

    [Theory, AutoData]
    internal void MapToBookAdvert_Status_Should_BeEquelToSource(BookAdvertEntity entity)
    {
        // Arrange
        var fixture = new Fixture();
        fixture.Build<BookAdvertEntity>()
            .With(entity => entity.Status, () => new Random().Next(0, Enum.GetValues<BookAdvertStatus>().Length));

        // Act
        var bookAdvert = _mapper.Map<BookAdvert>(entity);

        // Assert
        bookAdvert.Status.Should()
            .NotBe(default)
            .And
            .Be((BookAdvertStatus)entity.Status);
    }

    [Theory, AutoData]
    internal void MapToBookAdvert_PhotoLinks_Should_BeSameCount(BookAdvertEntity entity)
    {
        // Act
        var bookAdvert = _mapper.Map<BookAdvert>(entity);

        // Assert
        bookAdvert.PhotoLinks.Should()
            .NotBeNullOrEmpty()
            .And
            .HaveCount(entity.PhotoLinks.Count);
    }

    [Theory, AutoData]
    internal void MapToBookAdvert_PhotoLinks_Should_BeEquelToSource(BookAdvertEntity entity)
    {
        // Act
        var bookAdvert = _mapper.Map<BookAdvert>(entity);

        // Assert
        bookAdvert.PhotoLinks.Should()
            .ContainInOrder(entity.PhotoLinks.Select(p => p.Link));
    }

    [Fact]
    internal void MapNullEnumerable_Should_ReturnEmptyCollection()
    {
        // Act
        var bookAdvert = _mapper.Map<ICollection<BookAdvert>>(null as IEnumerable<BookAdvert>);

        // Assert
        bookAdvert.Should()
        .BeEmpty()
            .And
        .HaveCount(0);
    }
}