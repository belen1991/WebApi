using shared.Shared;

namespace WebApi.Shared
{
  public static class UseCaseResultExtensions
  {
    public static bool NoResult<T>(this UseCaseResult<T, Failure> value)
    {
      return value.Failure() != null && value.Failure() is NoResult;
    }

    public static bool AccessDenied<T>(this UseCaseResult<T, Failure> value)
    {
      return value.Failure() != null && value.Failure() is AccessDenied;
    }

    public static bool UseCaseError<T>(this UseCaseResult<T, Failure> value)
    {
      return value.Failure() != null && value.Failure() is UseCaseError;
    }

    public static dynamic GetUseCaseErrorReason<T>(this UseCaseResult<T, Failure> value)
    {
      if (value == null || !(value.Failure() is UseCaseError useCaseError)) return string.Empty;
      return useCaseError.reason;
    }
  }
}
