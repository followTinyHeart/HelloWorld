/// <summary>
/// #1两数之和
/// for循环的嵌套使用
/// </summary>
/// <param name="nums"></param>
/// <param name="target"></param>
/// <returns></returns>
function TwoSum(nums , target)
{
    for (var i = 0; i < nums.length; i++) {
        var dif = target - nums[i];
        // j = i + 1 的目的是减少重复计算和避免两个元素下标相同
        for (var j = i + 1; j < nums.length; j++) {
            if (nums[j] == dif)
                return [i, j];
        }
    }
}


/// <summary>
/// 15#三数之和
/// </summary>
/// <param name="nums"></param>
/// <returns></returns>
function ThreeSum(nums)
{
    var res = [];

    if (nums.length <= 3) {
        if (nums.length == 3 && nums[0] + nums[1] + nums[2] == 0) {
            res.push(nums[0] + nums[1] + nums[2]);

            return res;
        }
    }

    for (var i = 0; i < nums.length - 2; i++) {             // 每个人
        for (var j = i + 1; j < nums.length - 1; j++) {     // 依次拉上其他每个人
            for (var k = j + 1; k < nums.length; k++) {     // 去问剩下的每个人
                if (nums[i] + nums[j] + nums[k] === 0) {    // 我们是不是可以一起组队
                    res.push([nums[i], nums[j], nums[k]]);
                }
            }
        }
    }

    return res;
}


/// <summary>
/// 16#最接近的三数之和
/// </summary>
/// <param name="nums"></param>
/// <param name="target"></param>
/// <returns></returns>
function ThreeSumClosest()
{

}
