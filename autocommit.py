#!/usr/bin/env python3
#encoding: UTF-8

import os
import sys

def change_editor(current_file):
    os.system("git config --local --replace-all  core.editor " + current_file) # 将当前脚本设置为editor
    os.system("git rebase -i") # 执行rebase，触发调用该脚本进行rebase
    os.system("git config --local --replace-all core.editor vim") # 执行完后将editor设置回vim

def rebase_commits(todo_file):
    with open(todo_file, "r+") as f:
        contents = f.read() # 读取git-rebase-todo文件内容
        contents = contents.split("\n")
        first_commit = True
        f.truncate()
        f.seek(0)
        for content in contents:
            if content.startswith("pick"):
                if first_commit:
                    first_commit = False
                else:
                    content = content.replace("pick", "squash") # 将除了第一个pick修改为squash
            f.write(content + "\n")

def main(args):
    if len(args) == 2:  # 如果将该脚本作为editor，git会调用该脚本，并以git-rebase-todo文件作为第2个参数
        rebase_commits(args[1])
    else:
        change_editor(os.path.abspath(args[0])) # 设置git editor

if __name__ == "__main__":
    main(sys.argv)
