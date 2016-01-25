WikiVis Project Strucutre
=========================

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
WikiVis
|
|__Builds  <- Unity and parser tool builds
|
|__Datas
|	|__Fetched  <- not clean datas
|	|__Final    <- parsed datas
|
|__Docs
|
|
|__Tools	<- wpf gui apps for tools (INFO for now: These tools will be maked in `Unity` with `Editors`)
|
|
|__WikiVisualizer <- UNITY PROJECT
	|__Assets
		|__GUI 
		|	|__Art
		|	|__Prefabs  <- prefabs like MapPlane
		|	|__Scripts  <- script like ui controllers and listeners
		|
		|__Scenes
		|
		|__Scrpts
			|__Abstractions <- abstractions for maps and datas
			|
			|__Data       <- implementation of tools for datas
			|	|__Editor <- editor scripts
			|
			|__Map	<- implmentations for maps
			|
			|__Tools <- third party tools 
				|__Editors <- editors that use extern tools
				|__ThirdParty <- classes writen in c# and also used in `wpf gui` project
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~