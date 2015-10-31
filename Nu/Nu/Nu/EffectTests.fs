﻿// Nu Game Engine.
// Copyright (C) Bryan Edds, 2013-2015.

namespace Nu.Tests
open System
open System.IO
open System.Xml
open OpenTK
open Xunit
open Prime
open Nu
module EffectTests =

    let [<Fact>] readEffectWorks () =

        Math.init ()

        let effectStr =
            "[Ifrit [Loop 10] [Some 20]
                [[FlameResource [AsResource
                    [Resource Gameplay Esper]]]
                 [FlameSprite [AsContent [FlamePosition]
                    [StaticSprite [ExpandResource FlameResource]
                        [[ExpandAspect FlamePosition]
                         [Color Over Linear [[[1 1 1 1] 10] [[0.8 0.25 0.25 0.75] 0]]]]]]]
                 [IfritSprite [AsContent []
                    [AnimatedSprite [Resource Gameplay Esper] [4 4] 4 16 6
                        [[Visible Over [[False 2] [True 16] [False 0]]]
                         [Position Sum Linear [[[0 0] 10] [[10 10] 0]]]
                         [Mount [ExpandContent FlameSprite [[PassAspect [Position Sum Linear [[[0 0] 10] [[10 10] 0]]]]]]]
                         [Mount [ExpandContent FlameSprite [[PassAspect [Position Sum Linear [[[10 0] 10] [[0 10] 0]]]]]]]
                         [Emit]]]]]]
                [ExpandContent IfritSprite []]]"

        let alucard =
            "[Alucard [Loop 16] 16
                [[Pose [AsResource
                    [Resource Gameplay AlucardWalkLeft]]]
                [AnimatedSprite [ResourceVar Pose] [4 4] [48 48] 5
                    [...]]]"
        ignore alucard

        let effect = (AlgebraicConverter typeof<Effect>).ConvertFromString effectStr :?> Effect
        Assert.Equal<string> ("Ifrit", effect.EffectName)