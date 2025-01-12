# FunscriptToSACSVConverter

## 概要
FunscriptをUFOSA・A10サイクロンSA用のCSVに変換するためのWindowsアプリです。

UFOSA・A10サイクロンSA用のCSVを作成するツールとして、[OpenFunScripter](https://github.com/OpenFunscripter/OFS)等を利用できるようにすることを目的として制作しました。

## 使い方
exeを起動し、変換したいFunscriptをウインドウにドラッグ&ドロップしてください。
exeと同じフォルダに、result.csv という名前で変換したスクリプトが出力されます。

## 変換内容

Funscriptの位置50をUFOSA・A10サイクロンSA用CSVの停止状態とし、位置100が正回転の速度100、位置0が逆回転の速度100として変換されます。

また、Funscriptが位置0から開始している場合、位置が0以外になるまでCSVも停止状態のままにします。
