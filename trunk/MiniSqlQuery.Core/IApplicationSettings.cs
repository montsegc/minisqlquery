using System;
using System.Data.Common;

namespace MiniSqlQuery.Core
{
	/// <summary>
	/// An interface for the application settings.
	/// </summary>
	public interface IApplicationSettings
	{
		/// <summary>
		/// Fired when the list of connection definitions is modified.
		/// </summary>
		/// <seealso cref="SetConnectionDefinitions"/>
		/// <seealso cref="GetConnectionDefinitions"/>
		event EventHandler ConnectionDefinitionsChanged;

		/// <summary>
		/// Fired when the database connection (provider and/or connection string) are modified.
		/// </summary>
		/// <seealso cref="ResetConnection"/>
		event EventHandler DatabaseConnectionReset;

		/// <summary>
		/// A reference to the current connection definiton class.
		/// </summary>
		DbConnectionDefinition ConnectionDefinition { get; set; }

		/// <summary>
        /// Gets an instance of <see cref="DbProviderFactory"/> depending on the value of <see cref="ConnectionDefinition"/>.
		/// </summary>
		DbProviderFactory ProviderFactory { get; }

		/// <summary>
		/// Gets an instance of <see cref="DbConnection"/> depending on the value of <see cref="ConnectionDefinition"/>.
		/// </summary>
		DbConnection Connection { get; }

		/// <summary>
		/// Gets the current connection definitions for this user.
		/// </summary>
		/// <returns>Connection definitions.</returns>
		DbConnectionDefinitionList GetConnectionDefinitions();

		/// <summary>
        /// Resets the list of connection definitions that are stored in the user profile.
		/// </summary>
        void SetConnectionDefinitions(DbConnectionDefinitionList definitionList);

		/// <summary>
		/// Resets the connection details firing the <see cref="DatabaseConnectionReset"/> event.
		/// </summary>
		/// <seealso cref="DatabaseConnectionReset"/>
		void ResetConnection();

		/// <summary>
		/// Helper method to get an open connection.
		/// </summary>
		/// <returns>A <see cref="DbConnection"/> object.</returns>
		DbConnection GetOpenConnection();

		/// <summary>
		/// Closes the current connection (if any).
		/// </summary>
		void CloseConnection();

		/// <summary>
		/// The default filter string for dialog boxes.
		/// </summary>
		string DefaultFileFilter { get; }

		/// <summary>
		/// Gets or sets a value indicating whether to enable query batching using the "GO" keyword.
		/// </summary>
		/// <value><c>true</c> if query batching is enabled; otherwise, <c>false</c>.</value>
		bool EnableQueryBatching { get; set; }

		/// <summary>
		/// Gets or sets the plug in file filter for finding the external plugins (e.g. "*.plugin.dll").
		/// </summary>
		/// <value>The plug in file filter.</value>
		string PlugInFileFilter { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to load plugins or not.
		/// </summary>
		/// <value><c>true</c> if [load plugins]; otherwise, <c>false</c>. The default is <c>true</c>.</value>
		bool LoadExternalPlugins { get; set; }

		/// <summary>
		/// Gets or sets the default connection definition filename. I blank the default is the users profile area.
		/// </summary>
		/// <value>The default connection definition filename.</value>
		string DefaultConnectionDefinitionFilename { get; set; }

		/// <summary>
		/// Gets, and increments, the "untitled document counter" starting at 1 for the "session".
		/// </summary>
		/// <value>The untitled document value.</value>
		int GetUntitledDocumentCounter();
	}
}
