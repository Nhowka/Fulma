namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Delete =

  module Types =

    type Option =
      | Size of ISize
      | Props of IHTMLProp list

    type Options =
      { size: string option
        props: IHTMLProp list }

      static member Empty =
        { size = None
          props = [] }

  open Types

  // Sizes
  let isSmall = Size IsSmall
  let isMedium = Size IsMedium
  let isLarge = Size IsLarge
  // Extra props
  let props props = Props props

  let delete (options: Option list) children =
    let parseOption (result: Options) opt =
        match opt with
        | Size size ->
            { result with size = ofSize size |> Some }
        | Props props ->
            { result with props = props }

    let opts = options |> List.fold parseOption Options.Empty

    a
      ( ClassName (Helpers.generateClassName bulma.delete.container [ opts.size ] )
        :> IHTMLProp
      :: opts.props)
      children
