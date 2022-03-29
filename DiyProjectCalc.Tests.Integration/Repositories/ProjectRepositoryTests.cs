﻿using SUT = DiyProjectCalc.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using DiyProjectCalc.TestHelpers.TestData;
using FluentAssertions;
using System.Linq;
using DiyProjectCalc.TestHelpers.TestFixtures;
using DiyProjectCalc.Core.Entities.ProjectAggregate;

namespace DiyProjectCalc.Tests.Integration.Repositories;

public class ProjectRepositoryTests : BaseDatabaseClassFixture
{
    private SUT.EFProjectRepository _repository;
    public ProjectRepositoryTests(DefaultTestDatabaseClassFixture fixture) : base(fixture) 
    {
        _repository = new SUT.EFProjectRepository(base.DbContext);
    }

    [Fact]
    [Trait("GetProjectAsync", "")]
    public async Task ValidProjectId_Returns_CorrectObject_For_GetProjectAsync()
    {
        //Arrange
        var expectedId = ProjectTestData.ValidProjectId(base.DbContext);

        //Act
        var result = await _repository.GetProjectAsync(expectedId);

        //Assert
        result.As<Project>().Id.Should().Be(expectedId);
    }

    [Fact]
    [Trait("GetAllProjectsAsync", "")]
    public async Task Returns_Projectss_For_GetAllProjectsAsync()
    {
        //Arrange

        //Act
        var result = await _repository.GetAllProjectsAsync();

        //Assert
        result.As<IEnumerable<Project>>().Should().HaveCount(ProjectTestData.ValidProjectListCount);
    }

    [Fact]
    [Trait("AddAsync", "")]
    public async Task ValidObject_Adds_Item_For_AddAsync()
    {
        //Arrange
        var newObject = ProjectTestData.NewProject;
        var beforeCount = base.DbContext.Projects.Count();

        //Act
        await _repository.AddAsync(newObject);

        //Assert
        var afterCount = base.DbContext.Projects.Count();
        afterCount.Should().Be(beforeCount + 1);
    }

    [Fact]
    [Trait("UpdateAsync", "")]
    public async Task ValidObject_Updates_Item_For_UpdateAsync()
    {
        //Arrange
        var objectToUpdate = ProjectTestData.ValidProject(base.DbContext);
        var objectId = default(int);
        if (objectToUpdate is not null)
        {
            objectToUpdate.Name = "edited project";
            objectId = objectToUpdate.Id;
        }

        //Act
        await _repository.UpdateAsync(objectToUpdate!);

        //Assert
        var result = base.DbContext.Projects.First(o => o.Id == objectId); 
        result.As<Project>().Name.Should().Be(objectToUpdate!.Name);
    }

    [Fact]
    [Trait("DeleteAsync", "")]
    public async Task ValidObject_Removes_Item_For_DeleteAsync()
    {
        //Arrange
        var objectToDelete = ProjectTestData.ValidProject(base.DbContext);
        var beforeCount = base.DbContext.Projects.Count();

        //Act
        await _repository.DeleteAsync(objectToDelete!);

        //Assert
        var afterCount = base.DbContext.Projects.Count();
        afterCount.Should().Be(beforeCount - 1);
    }
}
