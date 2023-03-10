# cursor-inaccessible-area

## WISS2022で配布したカーソル侵入不可能領域を生成するシステムです．

### 動作環境
Windows10 homeで動作を確認済み．ディスプレイの表示スケール100%以外，マルチディスプレイには非対応．


### 機能一覧

- 領域生成：領域左上のx,y座標と幅，高さを入力して領域を生成できます．

- 領域削除：全領域を削除します．

- 編集モード：領域をドラッグで移動，「ctrl+角をドラッグ」でサイズ変更が行えます．領域を右クリックして個別に削除することができます．編集モード中は領域の当たり判定が無効になります．

- 領域無効：領域の見た目と当たり判定を一時的に無効にします．領域無効を解除することで再度領域が有効になります．

- 色設定：全領域の色を一括で変更できます．

設定画面を閉じてもプログラムはバックグラウンドで実行されています．
タスクトレイアイコンから設定画面の表示やプログラムの終了が可能です．

### 注意事項
※万が一マウスカーソルの動作がおかしくなった場合はタスクマネージャーからプログラムを終了してください．

### 引用
もし本アプリや論文を引用する場合，以下をご利用ください．
```
大塲洋介，木下大樹，宮下芳明．カーソル進入不可領域による反応時間未満でのポインティング，第30回インタラクティブシステムとソフトウェアに関するワークショップ (WISS2022) 論文集，pp.1-3，2022．https://www.wiss.org/WISS2022Proceedings/data/T02.pdf
```

### YouTube
https://youtu.be/PbhyuTiwda4
