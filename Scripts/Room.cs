using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
  public int X1, Y1, X2, Y2;

  public int[,] roomData;

  public Room(int x1, int y1, int x2, int y2)
  {
    X1 = x1;
    Y1 = y1;
    X2 = x2;
    Y2 = y2;

    roomData = new int[X2 - X1, Y2 - Y1];
  }

  public bool isOverlap(Room other)
  {
    // 设 A, B 两个矩阵的左下角和右上角分别为 A1, A2, B1, B2
    // 如果 A 和 B 不重叠，那么 B 可能在 A 的左侧、右侧、上侧、下侧
    // 即 A2.y <= B1.y || A1.y >= B2.y || A2.x <= B1.x || A1.x >= B2.x
    // 则，两个矩阵重叠时，公式为 !(A2.y <= B1.y || A1.y >= B2.y || A2.x <= B1.x || A1.x >= B2.x)
    // 转换为 A2.y > B1.y && A1.y < B2.y && A2.x > B1.x && A1.x < B2.x

    int gutter = 2; // 为两个房间之间保留一定的间隙

    int left = other.X1 - gutter;
    int bottom = other.Y1 - gutter;
    int right = other.X2 + gutter;
    int top = other.Y2 + gutter;

    if (X2 > left && right > X1 && Y2 > bottom && top > Y1) {
      return true;
    }

    return false;
  }
}