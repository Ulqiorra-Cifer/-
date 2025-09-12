for _ in range(int(input())):
    n = int(input())
    nums = [int(i) for i in input().split()]
    answer = 0
    for k in nums:
        maybe_answer = sum(map(lambda x: k ^ x, nums))
        answer = max(answer, maybe_answer)
    print(answer)
