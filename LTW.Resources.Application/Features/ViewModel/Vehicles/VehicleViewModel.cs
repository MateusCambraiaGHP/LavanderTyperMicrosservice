﻿using LTW.Organization.Application.Features.ViewModel.Commom;
using System.Text.Json.Serialization;

namespace LTW.Resources.Application.Features.ViewModel.Vehicles
{
  public class VehicleViewModel : BaseViewModel
  {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    [JsonConstructor]
    public VehicleViewModel(string firstName, string lastName)
    {
      FirstName = firstName;
      LastName = lastName;
    }

    public VehicleViewModel() { }
  }
}
