# Minecraft Server Watchdog


This program monitors a specified folder for minecraft servers and parses files named `server.info` to stop and start them in the `.info` file you can specify a number of things, such as auto restart, server icon, name, startup command, etc.

## Server Info File Structure
If You want to leave a comment use //
you can use `=` in your entries since it's only split on the first `=`


The server file usually starts with a name defined like so

	name = Example Server


To define a server icon use the following,
Formats acceptable: `PNG`, `JPEG`, `GIF`
This file should be in the same directory as the server.

	icon = example.png


The following is an example on how to set a bunch of different information

	desc = Example Server Description
	mcver = 1.7.10
	modpack = FTB Infinity Evolved


To set the jar file for the server use:

	executable = forge-1.12.2-14.23.5.2847-universal.jar

Set the Min And Max Ram

	minRam = 128M
	maxRam = 8G

Flag Whether or not you want Experimental GC
This is `-XX:+UseG1GC -XX:+UnlockExperimentalVMOptions -XX:MaxGCPauseMillis=100 -XX:+DisableExplicitGC -XX:TargetSurvivorRatio=90 -XX:G1NewSizePercent=50 -XX:G1MaxNewSizePercent=80 -XX:G1MixedGCLiveThresholdPercent=50 -XX:+AlwaysPreTouch`

	experGC = true



Set Java Version

	java = 8

or

	java = 11

For Auto restart on crash use

	autoRestart = true

For automatic startup with the server use

	autoStart = true;
