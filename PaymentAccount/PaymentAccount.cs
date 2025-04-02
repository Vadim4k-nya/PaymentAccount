using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAccount
{
    [Serializable]
    public class PaymentAccount : ISerializable
    {
        public decimal DailyPayment { get; set; }
        public int NumberOfDays { get; set; }
        public decimal PenaltyPerDay { get; set; }
        public int DelayDays { get; set; }

        public decimal TotalWithoutPenalty => DailyPayment * NumberOfDays;
        public decimal Penalty => PenaltyPerDay * DelayDays;
        public decimal TotalWithPenalty => TotalWithoutPenalty + Penalty;

        public static bool SerializeComputedFields { get; set; } = true;

        PaymentAccount(decimal dailyPayment, int numberOfDays, decimal penaltyPerDay, int delayDays)
        {
            DailyPayment = dailyPayment;
            NumberOfDays = numberOfDays;
            PenaltyPerDay = penaltyPerDay;
            DelayDays = delayDays;
        }

        //метод для сериализации
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DailyPayment", DailyPayment);
            info.AddValue("NumberOfDays", NumberOfDays);
            info.AddValue("PenaltyPerDay", PenaltyPerDay);
            info.AddValue("DelayDays", DelayDays);

            if (SerializeComputedFields)
            {
                info.AddValue("TotalWithoutPenalty", TotalWithoutPenalty);
                info.AddValue("Penalty", Penalty);
                info.AddValue("TotalWithPenalty", TotalWithPenalty);
            }
        }
        //переопределение ToString для удобного вывода
        public override string ToString()
        {
            return $"Dayily Payment: {DailyPayment}\n" +
                $"Number of Days: {NumberOfDays}\n" +
                $"Penalty Per Day: {PenaltyPerDay}\n" +
                $"Delay Days: {DelayDays}\n" +
                $"Total Without Penalty: {TotalWithoutPenalty}\n" +
                $"Penalty: {Penalty}\n" +
                $"Total Woth Penalty: {TotalWithPenalty}";
        }
    }
}
