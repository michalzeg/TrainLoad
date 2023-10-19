﻿using StruCal.TrainLoad.Domain.Input;
using System.Collections.Generic;
using System.Linq;
using FEMPerimeter = FEM2DCommon.Sections.Perimeter;

namespace StruCal.TrainLoad.Domain.Extensions
{
    public static class PerimeterExtensions
    {
        public static FEMPerimeter Convert(this Perimeter perimeter)
        {
            var femPerimeter = new FEMPerimeter(perimeter.Coordinates.ToList());

            return femPerimeter;
        }

        public static List<FEMPerimeter> Convert(this IEnumerable<Perimeter> perimeters)
        {
            return perimeters.Select(e => e.Convert()).ToList();
        }
    }
}