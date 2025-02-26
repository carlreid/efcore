// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Microsoft.EntityFrameworkCore.Metadata
{
    /// <summary>
    ///     Represents a column in a view.
    /// </summary>
    public interface IViewColumn : IColumnBase
    {
        /// <summary>
        ///     Gets the containing view.
        /// </summary>
        IView View { get; }

        /// <summary>
        ///     Gets the property mappings.
        /// </summary>
        new IEnumerable<IViewColumnMapping> PropertyMappings { get; }

        /// <summary>
        ///     <para>
        ///         Creates a human-readable representation of the given metadata.
        ///     </para>
        ///     <para>
        ///         Warning: Do not rely on the format of the returned string.
        ///         It is designed for debugging only and may change arbitrarily between releases.
        ///     </para>
        /// </summary>
        /// <param name="options"> Options for generating the string. </param>
        /// <param name="indent"> The number of indent spaces to use before each new line. </param>
        /// <returns> A human-readable representation. </returns>
        string ToDebugString(MetadataDebugStringOptions options, int indent = 0)
        {
            var builder = new StringBuilder();
            var indentString = new string(' ', indent);

            builder.Append(indentString);

            var singleLine = (options & MetadataDebugStringOptions.SingleLine) != 0;
            if (singleLine)
            {
                builder.Append($"ViewColumn: {Table.Name}.");
            }

            builder.Append(Name).Append(" (");

            builder.Append(StoreType).Append(")");

            if (IsNullable)
            {
                builder.Append(" Nullable");
            }
            else
            {
                builder.Append(" NonNullable");
            }

            builder.Append(")");

            if (!singleLine && (options & MetadataDebugStringOptions.IncludeAnnotations) != 0)
            {
                builder.Append(AnnotationsToDebugString(indent + 2));
            }

            return builder.ToString();
        }
    }
}
