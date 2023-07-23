#!/bin/bash

#for displaying a tree of the entire project without the .gitignore files

tree -I 'bin|obj|node_modules|dist' -L 2