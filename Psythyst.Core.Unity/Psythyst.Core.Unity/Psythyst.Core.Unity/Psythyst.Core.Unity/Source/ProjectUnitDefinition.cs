using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

namespace Psythyst.Core.Unity
{
    /// <summary>
    /// ProjectUnitDefinition Class.
    /// </summary>
    [Serializable]
    public abstract class ProjectUnitDefinition : ScriptableObject
    {
        public bool OverrideGeneratorOrder = false;
        public bool OverridePostProcessorOrder = false;
    }

    /// <summary>
    /// ProjectUnitDefinition Class.
    /// </summary>
    [Serializable]
    public class ProjectUnitDefinition<TSource, TResult, TGenerator, TPostProcessor> : ProjectUnitDefinition
        where TGenerator : GeneratorDefinition<TSource, TResult> 
        where TPostProcessor : PostProcessorDefinition<TResult>

    {
        public List<TGenerator> GeneratorDefinitionList;
        public List<TPostProcessor> PostProcessorDefinitionList;

        public void Generate(TSource Model)
        {
            var ProjectUnit = new ProjectUnit<TSource, TResult>();

            var GeneratorList = GeneratorDefinitionList.Where(x => x.Enabled).Select(x => x.GetGenerator());
            var PostProcessorList = PostProcessorDefinitionList.Where(x => x.Enabled).Select(x => x.GetPostProcessor());

            ProjectUnit<TSource, TResult>
                .Run(Model, 
                GeneratorList, 
                PostProcessorList, 
                !OverrideGeneratorOrder, 
                !OverridePostProcessorOrder);

            AssetDatabase.Refresh();
        }
    }
}