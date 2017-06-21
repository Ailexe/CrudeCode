# -*- coding: utf-8 -*-
import sys

# 引数を入れる変数
args = sys.argv[1:]

#指定された名前のファイルを開く関数
def openMdFile(name):
    f = open(name, 'r')
    lines = []

    for line in f:
        lines.append(line)
    
    return lines

#それぞれの行に対してタグづけを行う
def taggedLines(text):
    tags = []
    for line in lines:
        words = line.split(" ")
        if words[0] == "#":
            tags.append(0)
        elif words[0] == "##":
            tags.append(1)
        elif words[0] == "###":
            tags.append(2)
        else:
            tags.append(3)
    return tags

#本文から辞書を作成
def makeDict(lines, tags):
    dic = {}
    sDict = {}
    for x in range(0, len(lines)):
        sentence = ""
        if tags[x] == 2:
            hedline_s = lines[x].split(" ")
            word_s = hedline_s[1]
            for downX in range(x+1, len(lines)):
                if tags[downX] == 3:
                    sentence += lines[downX]
                else:
                    sDict[word_s[0:len(word_s)-1]] = sentence
                    break
            mDict = {}
            for upX in reversed(range(x)):
                if tags[upX] == 1:
                    hedline_m = lines[upX].split(" ")
                    word_m = hedline_m[1]
                    mDict[word_m[0:len(word_m)-1]] = sDict
                elif tags[upX] == 0:
                    hedline_l = lines[upX].split(" ")
                    word_l = hedline_l[1]
                    dic[word_l[0:len(word_l)-1]] = mDict
                    break
    return dic

#引数から要素を検索する
def getElement(dic, args):
    if len(args)-1 == 1:
        try:
            print(dic[args[1]])
        except KeyError:
            print("not find element")
    elif len(args)-1 == 2:
        try:
            print(dic[args[1]][args[2]])
        except KeyError:
            print("not find element")
    elif len(args)-1 == 3:
        try:
            print(dic[args[1]][args[2]][args[3]])
        except KeyError:
            print("not find element")

#メイン関数
if __name__ == "__main__":
    lines = openMdFile(args[0])
    tags = taggedLines(lines)
    dic = makeDict(lines, tags)
    getElement(dic, args)


