// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microsoft.EntityFrameworkCore.Design
{
    /// <summary>
    ///     Implemented by database providers to control which <see cref="IAnnotation" />s need to
    ///     have code generated (as opposed to being handled by convention) and then to generate
    ///     the code if needed.
    /// </summary>
    public interface IAnnotationCodeGenerator
    {
        /// <summary>
        ///     For the given property annotations, removes annotations that are either handled by convention or
        ///     have a corresponding fluent API, and return a list of fluent API calls for the latter.
        /// </summary>
        /// <param name="property"> The <see cref="IProperty" /> for which code should be generated. </param>
        /// <param name="annotations">
        ///     The list of annotations to handle. Handled annotations are removed from this list, and
        ///     unhandled ones kept.
        /// </param>
        /// <returns> A list of <see cref="MethodCallCodeFragment"/> instances for handled annotations. </returns>
        List<MethodCallCodeFragment> HandleAnnotations(IProperty property, List<IAnnotation> annotations);

        /// <summary>
        ///     Checks if the given <see cref="IAnnotation" /> is handled by convention when
        ///     applied to the given <see cref="IModel" />.
        /// </summary>
        /// <param name="model"> The <see cref="IModel" />. </param>
        /// <param name="annotation"> The <see cref="IAnnotation" />. </param>
        /// <returns>
        ///     <see langword="true"/> if the annotation is handled by convention;
        ///     <see langword="false"/> if code must be generated.
        /// </returns>
        bool IsHandledByConvention([NotNull] IModel model, [NotNull] IAnnotation annotation);

        /// <summary>
        ///     Checks if the given <see cref="IAnnotation" /> is handled by convention when
        ///     applied to the given <see cref="IEntityType" />.
        /// </summary>
        /// <param name="entityType"> The <see cref="IEntityType" />. </param>
        /// <param name="annotation"> The <see cref="IAnnotation" />. </param>
        /// <returns>
        ///     <see langword="true"/> if the annotation is handled by convention;
        ///     <see langword="false"/> if code must be generated.
        /// </returns>
        bool IsHandledByConvention([NotNull] IEntityType entityType, [NotNull] IAnnotation annotation);

        /// <summary>
        ///     Checks if the given <see cref="IAnnotation" /> is handled by convention when
        ///     applied to the given <see cref="IKey" />.
        /// </summary>
        /// <param name="key"> The <see cref="IKey" />. </param>
        /// <param name="annotation"> The <see cref="IAnnotation" />. </param>
        /// <returns>
        ///     <see langword="true"/> if the annotation is handled by convention;
        ///     <see langword="false"/> if code must be generated.
        /// </returns>
        bool IsHandledByConvention([NotNull] IKey key, [NotNull] IAnnotation annotation);

        /// <summary>
        ///     Checks if the given <see cref="IAnnotation" /> is handled by convention when
        ///     applied to the given <see cref="IProperty" />.
        /// </summary>
        /// <param name="property"> The <see cref="IProperty" />. </param>
        /// <param name="annotation"> The <see cref="IAnnotation" />. </param>
        /// <returns>
        ///     <see langword="true"/> if the annotation is handled by convention;
        ///     <see langword="false"/> if code must be generated.
        /// </returns>
        [Obsolete("Or just remove?")]
        bool IsHandledByConvention([NotNull] IProperty property, [NotNull] IAnnotation annotation);

        /// <summary>
        ///     Checks if the given <see cref="IAnnotation" /> is handled by convention when
        ///     applied to the given <see cref="IForeignKey" />.
        /// </summary>
        /// <param name="foreignKey"> The <see cref="IForeignKey" />. </param>
        /// <param name="annotation"> The <see cref="IAnnotation" />. </param>
        /// <returns>
        ///     <see langword="true"/> if the annotation is handled by convention;
        ///     <see langword="false"/> if code must be generated.
        /// </returns>
        bool IsHandledByConvention([NotNull] IForeignKey foreignKey, [NotNull] IAnnotation annotation);

        /// <summary>
        ///     Checks if the given <see cref="IAnnotation" /> is handled by convention when
        ///     applied to the given <see cref="IIndex" />.
        /// </summary>
        /// <param name="index"> The <see cref="IIndex" />. </param>
        /// <param name="annotation"> The <see cref="IAnnotation" />. </param>
        /// <returns>
        ///     <see langword="true"/> if the annotation is handled by convention;
        ///     <see langword="false"/> if code must be generated.
        /// </returns>
        bool IsHandledByConvention([NotNull] IIndex index, [NotNull] IAnnotation annotation);

        /// <summary>
        ///     Generates fluent API calls for the given <see cref="IAnnotation" />.
        /// </summary>
        /// <param name="model"> The <see cref="IModel" /> for which code should be generated. </param>
        /// <param name="annotation"> The <see cref="IAnnotation" /> for which code should be generated.</param>
        /// <returns> The generated code. </returns>
        MethodCallCodeFragment GenerateFluentApi([NotNull] IModel model, [NotNull] IAnnotation annotation);

        /// <summary>
        ///     Generates fluent API calls for the given <see cref="IAnnotation" />.
        /// </summary>
        /// <param name="entityType"> The <see cref="IEntityType" /> for which code should be generated. </param>
        /// <param name="annotation"> The <see cref="IAnnotation" /> for which code should be generated.</param>
        /// <returns> The generated code. </returns>
        MethodCallCodeFragment GenerateFluentApi([NotNull] IEntityType entityType, [NotNull] IAnnotation annotation);

        /// <summary>
        ///     Generates fluent API calls for the given <see cref="IAnnotation" />.
        /// </summary>
        /// <param name="key"> The <see cref="IKey" /> for which code should be generated. </param>
        /// <param name="annotation"> The <see cref="IAnnotation" /> for which code should be generated.</param>
        /// <returns> The generated code. </returns>
        MethodCallCodeFragment GenerateFluentApi([NotNull] IKey key, [NotNull] IAnnotation annotation);

        /// <summary>
        ///     Generates fluent API calls for the given <see cref="IAnnotation" />.
        /// </summary>
        /// <param name="property"> The <see cref="IProperty" /> for which code should be generated. </param>
        /// <param name="annotation"> The <see cref="IAnnotation" /> for which code should be generated.</param>
        /// <returns> The generated code. </returns>
        [Obsolete("Or just remove?")]
        MethodCallCodeFragment GenerateFluentApi([NotNull] IProperty property, [NotNull] IAnnotation annotation);

        /// <summary>
        ///     Generates fluent API calls for the given <see cref="IAnnotation" />.
        /// </summary>
        /// <param name="foreignKey"> The <see cref="IForeignKey" /> for which code should be generated. </param>
        /// <param name="annotation"> The <see cref="IAnnotation" /> for which code should be generated.</param>
        /// <returns> The generated code. </returns>
        MethodCallCodeFragment GenerateFluentApi([NotNull] IForeignKey foreignKey, [NotNull] IAnnotation annotation);

        /// <summary>
        ///     Generates fluent API calls for the given <see cref="IAnnotation" />.
        /// </summary>
        /// <param name="index"> The <see cref="IIndex" /> for which code should be generated. </param>
        /// <param name="annotation"> The <see cref="IAnnotation" /> for which code should be generated.</param>
        /// <returns> The generated code. </returns>
        MethodCallCodeFragment GenerateFluentApi([NotNull] IIndex index, [NotNull] IAnnotation annotation);
    }
}
