﻿// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
    /// <summary>
    /// Provides access to custom processor parameters, methods for converting member data, and triggering nested builds.
    /// </summary>
    public abstract class ContentProcessorContext
    {
        /// <summary>
        /// Gets the name of the current content build configuration.
        /// </summary>
        public abstract string BuildConfiguration { get; }

        /// <summary>
        /// Gets the path of the directory that will contain any intermediate files generated by the content processor.
        /// </summary>
        public abstract string IntermediateDirectory { get; }

        /// <summary>
        /// Gets the logger interface used for status messages or warnings.
        /// </summary>
        public abstract ContentBuildLogger Logger { get; }

        /// <summary>
        /// Gets the output path of the content processor.
        /// </summary>
        public abstract string OutputDirectory { get; }

        /// <summary>
        /// Gets the output file name of the content processor.
        /// </summary>
        public abstract string OutputFilename { get; }

        /// <summary>
        /// Gets the collection of parameters used by the content processor.
        /// </summary>
        public abstract OpaqueDataDictionary Parameters { get; }

        /// <summary>
        /// Gets the current content build target platform.
        /// </summary>
        public abstract TargetPlatform TargetPlatform { get; }

        /// <summary>
        /// Gets the current content build target profile.
        /// </summary>
        public abstract GraphicsProfile TargetProfile { get; }

        /// <summary>
        /// Initializes a new instance of ContentProcessorContext.
        /// </summary>
        public ContentProcessorContext()
        {
        }

        /// <summary>
        /// Adds a dependency to the specified file. This causes a rebuild of the file, when modified, on subsequent incremental builds.
        /// </summary>
        /// <param name="filename">Name of an asset file.</param>
        public abstract void AddDependency(string filename);

        /// <summary>
        /// Add a file name to the list of related output files maintained by the build item. This allows tracking build items that build multiple output files.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        public abstract void AddOutputFile(string filename);

        /// <summary>
        /// Initiates a nested build of the specified asset and then loads the result into memory.
        /// </summary>
        /// <typeparam name="TInput">Type of the input.</typeparam>
        /// <typeparam name="TOutput">Type of the converted output.</typeparam>
        /// <param name="sourceAsset">Reference to the source asset.</param>
        /// <param name="processorName">Optional processor for this content.</param>
        /// <returns>Copy of the final converted content.</returns>
        public TOutput BuildAndLoadAsset<TInput,TOutput>(
            ExternalReference<TInput> sourceAsset,
            string processorName
            )
        {
            return BuildAndLoadAsset<TInput, TOutput>(sourceAsset, processorName, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="sourceAsset"></param>
        /// <param name="processorName"></param>
        /// <param name="processorParameters"></param>
        /// <param name="importerName"></param>
        /// <returns></returns>
        public abstract TOutput BuildAndLoadAsset<TInput,TOutput>(
            ExternalReference<TInput> sourceAsset,
            string processorName,
            OpaqueDataDictionary processorParameters,
            string importerName
            );

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="sourceAsset"></param>
        /// <param name="processorName"></param>
        /// <returns></returns>
        public ExternalReference<TOutput> BuildAsset<TInput,TOutput>(
            ExternalReference<TInput> sourceAsset,
            string processorName
            )
        {
            return BuildAsset<TInput, TOutput>(sourceAsset, processorName, null, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="sourceAsset"></param>
        /// <param name="processorName"></param>
        /// <param name="processorParameters"></param>
        /// <param name="importerName"></param>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public abstract ExternalReference<TOutput> BuildAsset<TInput,TOutput>(
            ExternalReference<TInput> sourceAsset,
            string processorName,
            OpaqueDataDictionary processorParameters,
            string importerName,
            string assetName
            );

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="input"></param>
        /// <param name="processorName"></param>
        /// <returns></returns>
        public TOutput Convert<TInput,TOutput>(
            TInput input,
            string processorName
            )
        {
            return Convert<TInput, TOutput>(input, processorName, new OpaqueDataDictionary());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="input"></param>
        /// <param name="processorName"></param>
        /// <param name="processorParameters"></param>
        /// <returns></returns>
        public abstract TOutput Convert<TInput,TOutput>(
            TInput input,
            string processorName,
            OpaqueDataDictionary processorParameters
            );
    }
}
