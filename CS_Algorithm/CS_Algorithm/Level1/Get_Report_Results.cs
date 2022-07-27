using System;
using System.Collections;
using System.Collections.Generic;

namespace CS_Algorithm.Level1
{
    // 신입사원 무지는 게시판 불량 이용자를 신고하고 처리 결과를 메일로 발송하는
    // 시스템을 개발하려 합니다. 무지가 개발하려는 시스템은 다음과 같습니다.

    // - 각 유저는 한 번에 한 명의 유저를 신고할 수 있습니다.
    //   - 신고 횟수에 제한은 없습니다. 서로 다른 유저를 계속해서 신고할 수 있습니다.
    //   - 한 유저를 여러 번 신고할 수도 있지만, 동일한 유저에 대한 신고 횟수는 1회로
    //   - 처리됩니다.

    // - k번 이상 신고된 유저는 게시판 이용이 정지되며, 해당 유저를 신고한 모든 유저에게
    //   정지 사실을 메일로 발송합니다.
    //   - 유저가 신고한 모든 내용을 취합하여 마지막에 한꺼번에 게시판 이용 정지를 시키면서
    //   - 정지 메일을 발송합니다.

    class Get_Report_Results
    {
        public static int[] solution(string[] id_list, string[] report, int k)
        {
            int[] answer = new int[id_list.Length];

            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            for (int i = 0; i < report.Length; i++)
            {
                string[] str = report[i].Split(' ');

                string give = str[0];
                string take = str[1];

                if (!dic.ContainsKey(take))
                {
                    List<string> list = new List<string>();
                    list.Add(give);
                    dic.Add(take, list);
                    continue;
                }

                if (!dic[take].Contains(give))
                {
                    dic[take].Add(give);
                }
            }

            for (int i = 0; i < id_list.Length; i++)
            {
                foreach (KeyValuePair<string, List<string>> item in dic)
                {
                    if (item.Value.Contains(id_list[i]))
                    {
                        if (item.Value.Count >= k)
                        {
                            answer[i] = ++answer[i];
                        }
                    }
                }
            }

            return answer;
        }

        static void Main(string[] args)
        {
            string[] id_list = new string[] { "muzi", "frodo", "apeach", "neo" };
            string[] report = new string[] { "muzi frodo", "apeach frodo", "frodo neo", "muzi neo", "apeach muzi" };
            int k = 2;

            Console.WriteLine("answer is");
            foreach (int i in solution(id_list, report, k))
                Console.Write(i + ", ");
            Console.WriteLine();
        }
    }
}

