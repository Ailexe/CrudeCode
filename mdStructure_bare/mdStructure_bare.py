# -*- coding: utf-8 -*-
import sys

# 引数を入れる変数
args = sys.argv

#指定された名前のファイルを開く関数
def openMdFile(name):
    f = open(name, 'r')
    lines = []

    for line in f:
        lines.append(line)
    
    return lines

class mdFile:
    def __init__(self):
        self.para = paragraph()
        self.name = []

class paragraph:
    def __init__(self):
        self.midium = midium()
        self.name = []

class midium:
    def __init__(self):
        self.small = small()
        self.name = []

class small:
    def __init__(self):
        self.sentence = []

def md2Class(text):
    mdClass = []
    i = 0
    for line in text:
        word = line.split(" ")
        if word[0] == "#":
            mdClass.append(mdFile())
            mdClass[len(mdClass)-1].name = word[1]
            for x in range(i+1, len(text)):
                print(text[i])
                word1 = text[i].split(" ")
                if word1[0] == "##":
                    mdClass[len(mdClass)-1].para.name.append(word1[1])
        i = i+1
        
    return mdClass


#メイン関数
if __name__ == "__main__":
    lines = openMdFile(args[1])
    mdClass = md2Class(lines)

    for i in range(0, len(mdClass)):
        print(mdClass[i].name.para.name[0])
    


