namespace SimpleTenant.Web.Clients;

/// <summary>
/// Defines a contract for making HTTP requests to a remote API.
/// </summary>
public interface IApiClient
{
    /// <summary>
    /// Sends a GET request to the specified URL.
    /// </summary>
    /// <param name="url">The URL to send the GET request to.</param>
    /// <returns>A task that represents the HTTP response message.</returns>
    Task<T> GetAsync<T>(string url);

    /// <summary>
    /// Sends a POST request to the specified URL with the provided data.
    /// </summary>
    /// <param name="url">The URL to send the POST request to.</param>
    /// <param name="content">The data to send in the POST request.</param>
    /// <returns>A task that represents the HTTP response message.</returns>
    Task<T1> PostAsync<T1, T2>(string url, T2 content);

    /// <summary>
    /// Sends a PUT request to the specified URL with the provided data.
    /// </summary>
    /// <param name="url">The URL to send the PUT request to.</param>
    /// <param name="content">The data to send in the PUT request.</param>
    /// <returns>A task that represents the HTTP response message.</returns>
    Task<T1> PutAsync<T1, T2>(string url, T2 content);

    /// <summary>
    /// Sends a DELETE request to the specified URL.
    /// </summary>
    /// <param name="url">The URL to send the DELETE request to.</param>
    /// <returns>A task that represents the HTTP response message.</returns>
    Task<bool> DeleteAsync(string url);
}