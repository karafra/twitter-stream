using System;

namespace Tests.Fixtures;

/// <summary>
/// Dummy contract for teardown and setup of test methods
/// </summary>
public class BaseTestFixture : IDisposable
{
  /// <summary>
  /// Setup of test method
  /// </summary>
  public BaseTestFixture()
  {
    // Global setup before every test
  }

  /// <summary>
  /// Teardown of test method
  /// </summary>
  public virtual void Dispose()
  {
    // Global teardown before every test
  }
}