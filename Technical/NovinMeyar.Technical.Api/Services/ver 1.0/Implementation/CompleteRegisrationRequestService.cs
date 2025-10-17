using System;
using Serilog;
using MassTransit;
using System.Linq;
using System.Threading.Tasks;
using NovinMeyar.Technical.DataLayer;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.Technical.Domain.Entities;
using NovinMeyar.Technical.Domain.DTO;
using NovinMeyar.Common;
using NovinMeyar.Common.MessageBrokers;

namespace NovinMeyar.Technical.Api.Services.ver_1._0.Implementation
{
    public class CompleteRegisrationRequestService : ICompleteRegisrationRequestService
    {
        private readonly DataContext dataContext;
        private readonly ILogger logger;
        private readonly IRequestClient<RequestRegistrationBroker> client;
        public CompleteRegisrationRequestService(DataContext dataContext,
            IRequestClient<RequestRegistrationBroker> client,
            ILogger logger)
        {
            this.dataContext = dataContext;
            this.logger = logger;
            this.client = client;
        }

        //public async Task<ResponseModel> CompleteAsync(TechnicalInformationModel model, string userName, long branchId, string branchCode)
        //{
        //    var validation = OnValidateModel(model);
        //    if (!validation.Succeed)
        //        return validation;

        //    var response = new ResponseModel()
        //    {
        //        Succeed = false,
        //        HttpStatusCode = System.Net.HttpStatusCode.BadRequest
        //    };

        //    try
        //    {
        //        var elevator = await dataContext.ElevatorInformations.FindAsync(model.Id);
        //        elevator.LuxMeterSerialNo = model.LuxMeterSerialNo;
        //        elevator.PowerMeterSerialNo = model.PowerMeterSerialNo;
        //        elevator.TypeMeterSerialNo = model.TypeMeterSerialNo;
        //        elevator.MultiMeterSerialNo = model.MultiMeterSerialNo;
        //        elevator.LaserMeterSerialNo = model.LaserMeterSerialNo;
        //        elevator.CollisSerialNo = model.CollisSerialNo;
        //        elevator.ThicknessGaugeSerialNo = model.ThicknessGaugeSerialNo;
        //        elevator.UserModifiedDate = DateTime.Now;
        //        elevator.UserModifiedName = userName;

        //        var gTechInfo = await dataContext.GeneralTechnicalformations.FirstAsync(x => x.ElevatorInformationId == model.Id);
        //        if (gTechInfo == null)
        //        {
        //            await dataContext.GeneralTechnicalformations.AddAsync(new GeneralTechnicalformation
        //            {
        //                CabinSpeed = model.CabinSpeed,
        //                PathHeight = model.PathHeight,
        //                LowSpeed = model.LowSpeed,
        //                FloorCount = model.FloorCount,
        //                FloorLength = model.FloorLength,
        //                ManualTravelCalculation = model.ManualTravelCalculation,
        //                Travel = model.Travel,
        //                ElevatorCount = model.ElevatorCount,
        //                HasMachineRoom = model.HasMachineRoom,
        //                PitSituation = model.PitSituation,
        //                ShaftWidth = model.ShaftWidth,
        //                ShaftDepth = model.ShaftDepth,
        //                DepthOfPit = model.DepthOfPit,
        //                CabinStandHeight = model.CabinStandHeight,
        //                CounterWeightStandHeight = model.CounterWeightStandHeight,
        //                StandsDistance = model.StandsDistance,
        //                CounterWeightToStandDistance = model.CounterWeightToStandDistance,
        //                ShaftHeight = model.ShaftHeight,
        //                OverHead = model.OverHead,
        //                CabinToCounterWeightDistance = model.CabinToCounterWeightDistance,
        //                HasIncpectorDoorInPit = model.HasIncpectorDoorInPit,
        //                IsHalfCloseShaft = model.IsHalfCloseShaft,
        //                HasShareShaft = model.HasShareShaft,
        //                HasEmergencyDoor = model.HasEmergencyDoor,
        //                HasVisitFromShaft = model.HasVisitFromShaft,
        //                MachineRoomHieght = model.MachineRoomHieght,
        //                ThreePahseSerialNo = model.ThreePahseSerialNo,
        //                ElevatorPhoneNumber = model.ElevatorPhoneNumber,
        //                UserCreatorName = userName,
        //                CreateDate = DateTime.Now,
        //                GovernerLocationId = model.GovernerLocationId
        //            });
        //        }
        //        else
        //        {
        //            gTechInfo.CabinSpeed = model.CabinSpeed;
        //            gTechInfo.PathHeight = model.PathHeight;
        //            gTechInfo.LowSpeed = model.LowSpeed;
        //            gTechInfo.FloorCount = model.FloorCount;
        //            gTechInfo.FloorLength = model.FloorLength;
        //            gTechInfo.ManualTravelCalculation = model.ManualTravelCalculation;
        //            gTechInfo.Travel = model.Travel;
        //            gTechInfo.ElevatorCount = model.ElevatorCount;
        //            gTechInfo.HasMachineRoom = model.HasMachineRoom;
        //            gTechInfo.PitSituation = model.PitSituation;
        //            gTechInfo.ShaftWidth = model.ShaftWidth;
        //            gTechInfo.ShaftDepth = model.ShaftDepth;
        //            gTechInfo.DepthOfPit = model.DepthOfPit;
        //            gTechInfo.CabinStandHeight = model.CabinStandHeight;
        //            gTechInfo.CounterWeightStandHeight = model.CounterWeightStandHeight;
        //            gTechInfo.StandsDistance = model.StandsDistance;
        //            gTechInfo.CounterWeightToStandDistance = model.CounterWeightToStandDistance;
        //            gTechInfo.ShaftHeight = model.ShaftHeight;
        //            gTechInfo.OverHead = model.OverHead;
        //            gTechInfo.CabinToCounterWeightDistance = model.CabinToCounterWeightDistance;
        //            gTechInfo.HasIncpectorDoorInPit = model.HasIncpectorDoorInPit;
        //            gTechInfo.IsHalfCloseShaft = model.IsHalfCloseShaft;
        //            gTechInfo.HasShareShaft = model.HasShareShaft;
        //            gTechInfo.HasEmergencyDoor = model.HasEmergencyDoor;
        //            gTechInfo.HasVisitFromShaft = model.HasVisitFromShaft;
        //            gTechInfo.MachineRoomHieght = model.MachineRoomHieght;
        //            gTechInfo.ThreePahseSerialNo = model.ThreePahseSerialNo;
        //            gTechInfo.ElevatorPhoneNumber = model.ElevatorPhoneNumber;
        //            gTechInfo.UserModifiedDate = DateTime.Now;
        //            gTechInfo.UserModifiedName = userName;
        //            gTechInfo.GovernerLocationId = model.GovernerLocationId;
        //        }

        //        var cabinInformation = await dataContext.CabinInformations.FirstAsync(x => x.ElevatorInformationId == model.Id);
        //        if (cabinInformation == null)
        //        {
        //            await dataContext.CabinInformations.AddAsync(new CabinInformation
        //            {
        //                CarCapacityCount = model.CarCapacityCount,
        //                CarCapacityWeight = model.CarCapacityWeight,
        //                VerticalShoesDistance = model.VerticalShoesDistance,
        //                ShoesTypeId = model.ShoesTypeId,
        //                InstallRailEquipment = model.InstallRailEquipment,
        //                Maux = model.Maux,
        //                CabinDepth = model.CabinDepth,
        //                CabinHeight = model.CabinHeight,
        //                CabinWidth = model.CabinWidth,
        //                WallMaterialTypeId = model.WallMaterialTypeId,
        //                BedMaterialTypeId = model.BedMaterialTypeId,
        //                CarWeight = model.CarWeight,
        //                CabinTrayHeight = model.CabinTrayHeight,
        //                HasLightSensor = model.HasLightSensor,
        //                HasCarLockDoor = model.HasCarLockDoor,
        //                UserCreatorName = userName,
        //                CreateDate = DateTime.Now
        //            });
        //        }
        //        else
        //        {
        //            cabinInformation.CarCapacityCount = model.CarCapacityCount;
        //            cabinInformation.CarCapacityWeight = model.CarCapacityWeight;
        //            cabinInformation.VerticalShoesDistance = model.VerticalShoesDistance;
        //            cabinInformation.ShoesTypeId = model.ShoesTypeId;
        //            cabinInformation.InstallRailEquipment = model.InstallRailEquipment;
        //            cabinInformation.Maux = model.Maux;
        //            cabinInformation.CabinDepth = model.CabinDepth;
        //            cabinInformation.CabinHeight = model.CabinHeight;
        //            cabinInformation.CabinWidth = model.CabinWidth;
        //            cabinInformation.WallMaterialTypeId = model.WallMaterialTypeId;
        //            cabinInformation.BedMaterialTypeId = model.BedMaterialTypeId;
        //            cabinInformation.CarWeight = model.CarWeight;
        //            cabinInformation.CabinTrayHeight = model.CabinTrayHeight;
        //            cabinInformation.HasLightSensor = model.HasLightSensor;
        //            cabinInformation.HasCarLockDoor = model.HasCarLockDoor;
        //            cabinInformation.UserModifiedDate = DateTime.Now;
        //            cabinInformation.UserModifiedName = userName;
        //        }

        //        foreach (var item in model.CabinAntiShocksInformations)
        //        {
        //            var objCabinAntiShocksInformation = await dataContext.CabinAntiShocksInformations.FindAsync(item.Id);
        //            if (objCabinAntiShocksInformation == null)
        //            {
        //                item.CabinAntiShockInstallationTypeId = model.CabinAntiShockInstallationTypeId;
        //                item.CabinAntiShockTypeId = model.CabinAntiShockTypeId;
        //                item.ElevatorInformationId = model.Id;
        //                item.UserCreatorName = userName;
        //                item.CreateDate = DateTime.Now;
        //                await dataContext.CabinAntiShocksInformations.AddAsync(item);
        //            }
        //            else
        //            {
        //                objCabinAntiShocksInformation.CabinAntiShockInstallationTypeId = item.CabinAntiShockInstallationTypeId;
        //                objCabinAntiShocksInformation.CabinAntiShockTypeCount = item.CabinAntiShockTypeCount;
        //                objCabinAntiShocksInformation.CabinAntiShockTypeId = item.CabinAntiShockTypeId;
        //                objCabinAntiShocksInformation.CabinAntiShockTypeSerialNo = item.CabinAntiShockTypeSerialNo;
        //                objCabinAntiShocksInformation.CabinCapacityWeight = item.CabinCapacityWeight;
        //                objCabinAntiShocksInformation.UserModifiedDate = DateTime.Now;
        //                objCabinAntiShocksInformation.UserModifiedName = userName;
        //            }
        //        }

        //        foreach (var item in model.DoorLockInformations)
        //        {
        //            var objDoorLockInformation = await dataContext.MechanicalDoorLockInformations.FirstOrDefaultAsync(x => x.Id == item.Id);
        //            if (objDoorLockInformation == null)
        //            {
        //                item.ElevatorInformationId = model.Id;
        //                item.UserCreatorName = userName;
        //                item.CreateDate = DateTime.Now;
        //                await dataContext.MechanicalDoorLockInformations.AddAsync(item);
        //            }
        //            else
        //            {
        //                objDoorLockInformation.LockTypeId = item.LockTypeId;
        //                objDoorLockInformation.SerialNo = item.SerialNo;
        //                objDoorLockInformation.UserModifiedDate = DateTime.Now;
        //                objDoorLockInformation.UserModifiedName = userName;
        //            }
        //        }

        //        foreach (var item in model.CounterWightAntiShocksInformations)
        //        {
        //            var objCounterWightAntiShocksInformation = await dataContext.CounterWightAntiShocksInformations.FirstOrDefaultAsync(x => x.Id == item.Id);
        //            if (objCounterWightAntiShocksInformation == null)
        //            {
        //                item.CounterWeightInstallationTypeId = model.CounterWeightInstallationTypeId;
        //                item.CounterWeightAntiShockTypeId = model.CounterWightAntiShockTypeId;
        //                item.ElevatorInformationId = model.Id;
        //                item.UserCreatorName = userName;
        //                item.CreateDate = DateTime.Now;
        //                await dataContext.CounterWightAntiShocksInformations.AddAsync(item);
        //            }
        //            else
        //            {
        //                objCounterWightAntiShocksInformation.CounterCapacityWeight = item.CounterCapacityWeight;
        //                objCounterWightAntiShocksInformation.CounterWeightAntiShockTypeCount = item.CounterWeightAntiShockTypeCount;
        //                objCounterWightAntiShocksInformation.CounterWeightAntiShockTypeId = item.CounterWeightAntiShockTypeId;
        //                objCounterWightAntiShocksInformation.CounterWeightAntiShockTypeSerialNo = item.CounterWeightAntiShockTypeSerialNo;
        //                objCounterWightAntiShocksInformation.CounterWeightInstallationTypeId = item.CounterWeightInstallationTypeId;
        //                objCounterWightAntiShocksInformation.CounterWeightAntiShockTypeBrandId = item.CounterWeightAntiShockTypeBrandId;
        //                objCounterWightAntiShocksInformation.UserModifiedDate = DateTime.Now;
        //                objCounterWightAntiShocksInformation.UserModifiedName = userName;
        //            }
        //        }

        //        foreach (var item in model.SafetyBrakesInformations)
        //        {
        //            var objSafetyBrakesInformation = await dataContext.SafetyBrakesInformations.FirstOrDefaultAsync(x => x.Id == item.Id);
        //            if (objSafetyBrakesInformation == null)
        //            {
        //                item.ElevatorInformationId = model.Id;
        //                item.UserCreatorName = userName;
        //                item.CreateDate = DateTime.Now;
        //                await dataContext.SafetyBrakesInformations.AddAsync(item);
        //            }
        //            else
        //            {
        //                objSafetyBrakesInformation.BrakeTypeId = item.BrakeTypeId;
        //                objSafetyBrakesInformation.SafetyBrakesTypeId = item.SafetyBrakesTypeId;
        //                objSafetyBrakesInformation.CapacityWeight = item.CapacityWeight;
        //                objSafetyBrakesInformation.MaximumSpeed = item.MaximumSpeed;
        //                objSafetyBrakesInformation.LocationTypeId = item.LocationTypeId;
        //                objSafetyBrakesInformation.SerialNo = item.SerialNo;
        //                objSafetyBrakesInformation.TangleSide = item.TangleSide;
        //                objSafetyBrakesInformation.UserModifiedDate = DateTime.Now;
        //                objSafetyBrakesInformation.UserModifiedName = userName;
        //            }
        //        }

        //        foreach (var item in model.GovernerInformations)
        //        {
        //            var objGovernerInformation = await dataContext.GovernerInformations.FirstOrDefaultAsync(x => x.Id == item.Id);
        //            if (objGovernerInformation == null)
        //            {
        //                item.ElevatorInformationId = model.Id;
        //                item.UserCreatorName = userName;
        //                item.CreateDate = DateTime.Now;
        //                await dataContext.GovernerInformations.AddAsync(item);
        //            }
        //            else
        //            {
        //                objGovernerInformation.GovernerTypeId = item.GovernerTypeId;
        //                objGovernerInformation.HasTwoWays = item.HasTwoWays;
        //                objGovernerInformation.MaximumValidSpeed = item.MaximumValidSpeed;
        //                objGovernerInformation.SerialNo = item.SerialNo;
        //                objGovernerInformation.UserModifiedDate = DateTime.Now;
        //                objGovernerInformation.UserModifiedName = userName;
        //            }
        //        }

        //        if (model.SteeringControlInformation != null)
        //        {
        //            var objSteeringControlInformation = await dataContext.SteeringControlInformations
        //                .FirstOrDefaultAsync(x => x.Id == model.SteeringControlInformation.Id);

        //            if (objSteeringControlInformation == null)
        //            {
        //                model.SteeringControlInformation.ElevatorInformationId = model.Id;
        //                model.SteeringControlInformation.UserCreatorName = userName;
        //                model.SteeringControlInformation.CreateDate = DateTime.Now;
        //                await dataContext.SteeringControlInformations.AddAsync(model.SteeringControlInformation);
        //            }
        //            else
        //            {
        //                objSteeringControlInformation.TravelingCableTypeId = model.SteeringControlInformation.TravelingCableTypeId;
        //                objSteeringControlInformation.LineCount = model.SteeringControlInformation.LineCount;
        //                objSteeringControlInformation.HasEmergencyKey = model.SteeringControlInformation.HasEmergencyKey;
        //                objSteeringControlInformation.SerialNo = model.SteeringControlInformation.SerialNo;
        //                objSteeringControlInformation.BoardTypeId = model.SteeringControlInformation.BoardTypeId;
        //                objSteeringControlInformation.CableCount = model.SteeringControlInformation.CableCount;
        //                objSteeringControlInformation.CableTickness = model.SteeringControlInformation.CableTickness;
        //                objSteeringControlInformation.UserModifiedDate = DateTime.Now;
        //                objSteeringControlInformation.UserModifiedName = userName;
        //            }
        //        }


        //        if (model.EnginRoomInformation != null)
        //        {
        //            var objEngineInformation = await dataContext.EngineInformations
        //                .FirstOrDefaultAsync(x => x.Id == model.EnginRoomInformation.Id);

        //            if (objEngineInformation == null)
        //            {
        //                model.EnginRoomInformation.ElevatorInformationId = model.Id;
        //                model.EnginRoomInformation.UserCreatorName = userName;
        //                model.EnginRoomInformation.CreateDate = DateTime.Now;
        //                await dataContext.EngineInformations.AddAsync(model.EnginRoomInformation);
        //            }
        //            else
        //            {
        //                objEngineInformation.AlphaAngle = model.EnginRoomInformation.AlphaAngle;
        //                objEngineInformation.AlphaResult = model.EnginRoomInformation.AlphaResult;
        //                objEngineInformation.BetaAngle = model.EnginRoomInformation.BetaAngle;
        //                objEngineInformation.ConversionRatio = model.EnginRoomInformation.ConversionRatio;
        //                objEngineInformation.CounterWeightDistanceToNextWall = model.EnginRoomInformation.CounterWeightDistanceToNextWall;
        //                objEngineInformation.CounterWeightDistanceToWall = model.EnginRoomInformation.CounterWeightDistanceToWall;
        //                objEngineInformation.EngineSpeed = model.EnginRoomInformation.EngineSpeed;
        //                objEngineInformation.EngineTypeId = model.EnginRoomInformation.EngineTypeId;
        //                objEngineInformation.EngineWeight = model.EnginRoomInformation.EngineWeight;
        //                objEngineInformation.GammaAngle = model.EnginRoomInformation.GammaAngle;
        //                objEngineInformation.GavernerDistanceToNextWall = model.EnginRoomInformation.GavernerDistanceToNextWall;
        //                objEngineInformation.GavernerDistanceToWall = model.EnginRoomInformation.GavernerDistanceToWall;
        //                objEngineInformation.GearboxEfficiency = model.EnginRoomInformation.GearboxEfficiency;
        //                objEngineInformation.GeerRatio = model.EnginRoomInformation.GeerRatio;
        //                objEngineInformation.GeerTypeId = model.EnginRoomInformation.GeerTypeId;
        //                objEngineInformation.GovernerLocationTypeId = model.EnginRoomInformation.GovernerLocationTypeId;
        //                objEngineInformation.GripesCount = model.EnginRoomInformation.GripesCount;
        //                objEngineInformation.GrooveCount = model.EnginRoomInformation.GrooveCount;
        //                objEngineInformation.GrooveMeachanics = model.EnginRoomInformation.GrooveMeachanics;
        //                objEngineInformation.GrooveType = model.EnginRoomInformation.GrooveType;
        //                objEngineInformation.HasGeer = model.EnginRoomInformation.HasGeer;
        //                objEngineInformation.HighSpeed = model.EnginRoomInformation.HighSpeed;
        //                objEngineInformation.HorizontalDistanceWires = model.EnginRoomInformation.HorizontalDistanceWires;
        //                objEngineInformation.LowSpeed = model.EnginRoomInformation.LowSpeed;
        //                objEngineInformation.ManualAlphaLength = model.EnginRoomInformation.ManualAlphaLength;
        //                objEngineInformation.ManualCalculation = model.EnginRoomInformation.ManualCalculation;
        //                objEngineInformation.ManualEngineSpeed = model.EnginRoomInformation.ManualEngineSpeed;
        //                objEngineInformation.MaxPressureOnTractionPullyEfficiency = model.EnginRoomInformation.MaxPressureOnTractionPullyEfficiency;
        //                objEngineInformation.ModelName = model.EnginRoomInformation.ModelName;
        //                objEngineInformation.NuminalStream = model.EnginRoomInformation.NuminalStream;
        //                objEngineInformation.OutputPower = model.EnginRoomInformation.OutputPower;
        //                objEngineInformation.RopeCountOnTractionPullyEfficiency = model.EnginRoomInformation.RopeCountOnTractionPullyEfficiency;
        //                objEngineInformation.SerialNo = model.EnginRoomInformation.SerialNo;
        //                objEngineInformation.StartStream = model.EnginRoomInformation.StartStream;
        //                objEngineInformation.TractionPullyDiameter = model.EnginRoomInformation.TractionPullyDiameter;
        //                objEngineInformation.UnderCut = model.EnginRoomInformation.UnderCut;
        //                objEngineInformation.VerticalDistanceWires = model.EnginRoomInformation.VerticalDistanceWires;
        //                objEngineInformation.UserModifiedDate = DateTime.Now;
        //                objEngineInformation.UserModifiedName = userName;
        //            }
        //        }


        //        foreach (var item in model.TractionPulleiesInformations)
        //        {
        //            var objTractionPulleiesInformation = await dataContext.TractionPulleiesInformations
        //                .FirstOrDefaultAsync(x => x.Id == item.Id);

        //            if (objTractionPulleiesInformation == null)
        //            {
        //                item.ElevatorInformationId = model.Id;
        //                item.CreateDate = DateTime.Now;
        //                item.UserCreatorName = userName;
        //                await dataContext.TractionPulleiesInformations.AddAsync(item);
        //            }
        //            else
        //            {
        //                objTractionPulleiesInformation.EngineTypeId = item.EngineTypeId;
        //                objTractionPulleiesInformation.HasWanderingSquare = item.HasWanderingSquare;
        //                objTractionPulleiesInformation.IsSquareReverse = item.IsSquareReverse;
        //                objTractionPulleiesInformation.LocationTypeId = item.LocationTypeId;
        //                objTractionPulleiesInformation.PulleyDiameter = item.PulleyDiameter;
        //                objTractionPulleiesInformation.PulleyMaterialTypeId = item.PulleyMaterialTypeId;
        //                objTractionPulleiesInformation.Quantity = item.Quantity;
        //                objTractionPulleiesInformation.SerialNo = item.SerialNo;
        //                objTractionPulleiesInformation.SquareReverseCount = item.SquareReverseCount;
        //                objTractionPulleiesInformation.TractionPulleyTypeId = item.TractionPulleyTypeId;
        //                objTractionPulleiesInformation.UserModifiedDate = DateTime.Now;
        //                objTractionPulleiesInformation.UserModifiedName = userName;
        //            }
        //        }

        //        if(model.RailsInformation!=null)
        //        {
        //            var objRailsInformation = dataContext.RailsInformations.FirstOrDefault(x => x.Id == model.RailsInformation.Id);
        //            if (objRailsInformation != null)
        //            {
        //                model.RailsInformation.ElevatorInformationId = model.Id;
        //                model.RailsInformation.CreateDate = DateTime.Now;
        //                model.RailsInformation.UserCreatorName = userName;
        //                await dataContext.RailsInformations.AddAsync(model.RailsInformation);
        //            }
        //            else
        //            {
        //                objRailsInformation.AnchorCenterDistanceFromRailX = model.RailsInformation.AnchorCenterDistanceFromRailX;
        //                objRailsInformation.AnchorCenterDistanceFromRailY = model.RailsInformation.AnchorCenterDistanceFromRailY;
        //                objRailsInformation.b1 = model.RailsInformation.b1;
        //                objRailsInformation.BracketDistance = model.RailsInformation.BracketDistance;
        //                objRailsInformation.CabinCenterDistanceFromRailX = model.RailsInformation.CabinCenterDistanceFromRailX;
        //                objRailsInformation.CabinCenterDistanceFromRailY = model.RailsInformation.CabinCenterDistanceFromRailY;
        //                objRailsInformation.CabinCenterDistanceMassFromRailX = model.RailsInformation.CabinCenterDistanceMassFromRailX;
        //                objRailsInformation.CabinCenterDistanceMassFromRailY = model.RailsInformation.CabinCenterDistanceMassFromRailY;
        //                objRailsInformation.CabinDoorDistanceFromRailX = model.RailsInformation.CabinDoorDistanceFromRailX;
        //                objRailsInformation.CabinDoorDistanceFromRailY = model.RailsInformation.CabinDoorDistanceFromRailY;
        //                objRailsInformation.CabinRailCount = model.RailsInformation.CabinRailCount;
        //                objRailsInformation.CabinRailDistance = model.RailsInformation.CabinRailDistance;
        //                objRailsInformation.CabinRailTypeId = model.RailsInformation.CabinRailTypeId;
        //                objRailsInformation.CounterWeightRailCount = model.RailsInformation.CounterWeightRailCount;
        //                objRailsInformation.CounterWeightRailDistance = model.RailsInformation.CounterWeightRailDistance;
        //                objRailsInformation.CounterWeightRailTypeId = model.RailsInformation.CounterWeightRailTypeId;
        //                objRailsInformation.h1 = model.RailsInformation.h1;
        //                objRailsInformation.K = model.RailsInformation.K;
        //                objRailsInformation.ManualRailDetail = model.RailsInformation.ManualRailDetail;
        //                objRailsInformation.PressureOnRail = model.RailsInformation.PressureOnRail;
        //                objRailsInformation.RailInstallationType = model.RailsInformation.RailInstallationType;
        //                objRailsInformation.RailLength = model.RailsInformation.RailLength;
        //                objRailsInformation.UserModifiedName = userName;
        //                objRailsInformation.UserModifiedDate = DateTime.Now;
        //            }
        //        }


        //        if (model.SteelRopeInformation != null)
        //        {
        //            var objSteelRopeInformation = await dataContext.SteelRopeInformations.FirstOrDefaultAsync(x => x.Id == model.SteelRopeInformation.Id);
        //            if (objSteelRopeInformation == null)
        //            {
        //                model.SteelRopeInformation.ElevatorInformationId = model.Id;
        //                model.SteelRopeInformation.UserCreatorName = userName;
        //                model.SteelRopeInformation.CreateDate = DateTime.Now;
        //                await dataContext.SteelRopeInformations.AddAsync(model.SteelRopeInformation);
        //            }
        //            else
        //            {
        //                objSteelRopeInformation.CableDiameter = model.SteelRopeInformation.CableDiameter;
        //                objSteelRopeInformation.RopeCount = model.SteelRopeInformation.RopeCount;
        //                objSteelRopeInformation.RopeTypeId = model.SteelRopeInformation.RopeTypeId;
        //                objSteelRopeInformation.SuspendedLength = model.SteelRopeInformation.SuspendedLength;
        //                objSteelRopeInformation.UserModifiedDate = DateTime.Now;
        //                objSteelRopeInformation.UserModifiedName = userName;
        //            }
        //        }

        //        if(model.CounterWeightInformation!=null)
        //        {
        //            var objCounterWeightInformation = await dataContext.CounterWeightInformations.FirstOrDefaultAsync(x => x.Id == model.CounterWeightInformation.Id);
        //            if(objCounterWeightInformation == null)
        //            {
        //                model.CounterWeightInformation.ElevatorInformationId = model.Id;
        //                model.CounterWeightInformation.UserCreatorName = userName;
        //                model.CounterWeightInformation.CreateDate = DateTime.Now;
        //                await dataContext.CounterWeightInformations.AddAsync(model.CounterWeightInformation);
        //            }
        //            else
        //            {
        //                objCounterWeightInformation.LocationTypeId = model.CounterWeightInformation.LocationTypeId;
        //                objCounterWeightInformation.BalanceWeightTypeId = model.CounterWeightInformation.BalanceWeightTypeId;
        //                objCounterWeightInformation.BalanceRatio = model.CounterWeightInformation.BalanceRatio;
        //                objCounterWeightInformation.WeightShoesTypeId = model.CounterWeightInformation.WeightShoesTypeId;
        //                objCounterWeightInformation.BalanceWeightCount = model.CounterWeightInformation.BalanceWeightCount;
        //                objCounterWeightInformation.TotalWeight = model.CounterWeightInformation.TotalWeight;
        //                objCounterWeightInformation.UserModifiedDate = DateTime.Now;
        //                objCounterWeightInformation.UserModifiedName = userName;
        //            }
        //        }
               
        //        if(model.FloorDoorsInformation!=null)
        //        {
        //            var objFloorDoorsInformation = await dataContext.FloorDoorsInformations.FirstOrDefaultAsync(x => x.Id == model.FloorDoorsInformation.Id);
        //            if(objFloorDoorsInformation==null)
        //            {
        //                model.FloorDoorsInformation.ElevatorInformationId = model.Id;
        //                model.FloorDoorsInformation.CreateDate = DateTime.Now;
        //                model.FloorDoorsInformation.UserCreatorName = userName;
        //                await dataContext.FloorDoorsInformations.AddAsync(model.FloorDoorsInformation);
        //            }
        //            else
        //            {
        //                objFloorDoorsInformation.DoorTickness = model.FloorDoorsInformation.DoorTickness;
        //                objFloorDoorsInformation.DoorTypeId = model.FloorDoorsInformation.DoorTypeId;
        //                objFloorDoorsInformation.DoorWidth = model.FloorDoorsInformation.DoorWidth;
        //                objFloorDoorsInformation.LocationTypeId = model.FloorDoorsInformation.LocationTypeId;
        //                objFloorDoorsInformation.OpeningSide = model.FloorDoorsInformation.OpeningSide;
        //                objFloorDoorsInformation.ThresholdDepth = model.FloorDoorsInformation.ThresholdDepth;
        //                objFloorDoorsInformation.UserModifiedDate = DateTime.Now;
        //                objFloorDoorsInformation.UserModifiedName = userName;
        //            }
        //        }


        //        if (model.CabinDoor != null)
        //        {
        //            var objCabinDoor = await dataContext.CabinDoors.FirstOrDefaultAsync(x => x.Id == model.CabinDoor.Id);
        //            if (objCabinDoor == null)
        //            {
        //                model.CabinDoor.ElevatorInformationId = model.Id;
        //                model.CabinDoor.CreateDate = DateTime.Now;
        //                model.CabinDoor.UserCreatorName = userName;
        //                await dataContext.CabinDoors.AddAsync(model.CabinDoor);
        //            }
        //            else
        //            {
        //                objCabinDoor.LocationTypeId = model.CabinDoor.LocationTypeId;
        //                objCabinDoor.OpeningSide = model.CabinDoor.OpeningSide;
        //                objCabinDoor.CabinDoorDepth = model.CabinDoor.CabinDoorDepth;
        //                objCabinDoor.DoorHeight = model.CabinDoor.DoorHeight;
        //                objCabinDoor.DoorTypeId = model.CabinDoor.DoorTypeId;
        //                objCabinDoor.DoorWidth = model.CabinDoor.DoorWidth;
        //                objCabinDoor.EnteringDepth = model.CabinDoor.EnteringDepth;

        //                objCabinDoor.UserModifiedDate = DateTime.Now;
        //                objCabinDoor.UserModifiedName = userName;
        //            }
        //        }

        //        await dataContext.SaveChangesAsync();

        //        response.Message = "عملیات ثبت با موفقیت انجام شد";
        //        response.Succeed = true;
        //        response.HttpStatusCode = System.Net.HttpStatusCode.OK;
        //        return response;

        //    }
        //    catch (Exception ex)
        //    {
        //        //await transaction.RollbackAsync();
        //        logger.Error($"{DateTime.Now} - {nameof(CompleteRegisrationRequestService)} --> {nameof(CompleteAsync)} --> Error deatail: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}");
        //        response.Message = $"در ثبت اطلاعات مشکلی به وجود آمده است. همکاران بخش فناوری در اسرع وقت نسبت به رفع مشکل اقدام خواهند نمود. ErrorDetails: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}";
        //        response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
        //    }
        //    return response;
        //}
        public async Task<ResponseModel<TechnicalInformationModel>> GetAsync(long Id)
        {
            var result = new TechnicalInformationModel();
            var elevator = await dataContext.ElevatorInformations.FindAsync(Id);
            result.LuxMeterSerialNo = elevator.LuxMeterSerialNo;
            result.PowerMeterSerialNo = elevator.PowerMeterSerialNo;
            result.TypeMeterSerialNo = elevator.TypeMeterSerialNo;
            result.MultiMeterSerialNo = elevator.MultiMeterSerialNo;
            result.LaserMeterSerialNo = elevator.LaserMeterSerialNo;
            result.CollisSerialNo = elevator.CollisSerialNo;
            result.ThicknessGaugeSerialNo = elevator.ThicknessGaugeSerialNo;


            var genTech = await dataContext.GeneralTechnicalformations.FirstOrDefaultAsync(x => x.ElevatorInformationId == Id);
            result.FloorCount = genTech.FloorCount;
            result.FloorLength = genTech.FloorLength;
            result.ManualTravelCalculation = genTech.ManualTravelCalculation;
            result.Travel = genTech.Travel;
            result.ElevatorCount = genTech.ElevatorCount;
            result.HasMachineRoom = genTech.HasMachineRoom;
            result.PitSituation = genTech.PitSituation;
            result.ShaftWidth = genTech.ShaftWidth;
            result.ShaftDepth = genTech.ShaftDepth;
            result.DepthOfPit = genTech.DepthOfPit;
            result.CabinStandHeight = genTech.CabinStandHeight;
            result.CounterWeightStandHeight = genTech.CounterWeightStandHeight;
            result.StandsDistance = genTech.StandsDistance;
            result.CounterWeightToStandDistance = genTech.CounterWeightToStandDistance;
            result.ShaftHeight = genTech.ShaftHeight;
            result.OverHead = genTech.OverHead;
            result.CabinToCounterWeightDistance = genTech.CabinToCounterWeightDistance;
            result.HasIncpectorDoorInPit = genTech.HasIncpectorDoorInPit;
            result.IsHalfCloseShaft = genTech.IsHalfCloseShaft;
            result.HasShareShaft = genTech.HasShareShaft;
            result.HasEmergencyDoor = genTech.HasEmergencyDoor;
            result.HasVisitFromShaft = genTech.HasVisitFromShaft;
            result.MachineRoomHieght = genTech.MachineRoomHieght;
            result.ThreePahseSerialNo = genTech.ThreePahseSerialNo;


            result.RailsInformation = await dataContext.RailsInformations.FindAsync(Id);
            result.CounterWeightInformation = await dataContext.CounterWeightInformations.FindAsync(Id);
            result.SteelRopeInformation = await dataContext.SteelRopeInformations.FindAsync(Id);

            var cabinInfo = await dataContext.CabinInformations.FirstOrDefaultAsync(x => x.Id == Id);
            result.CarCapacityCount = cabinInfo.CarCapacityCount;
            result.CarCapacityWeight = cabinInfo.CarCapacityWeight;
            result.VerticalShoesDistance = cabinInfo.VerticalShoesDistance;
            result.ShoesTypeId = cabinInfo.ShoesTypeId;
            result.InstallRailEquipment = cabinInfo.InstallRailEquipment;
            result.Maux = cabinInfo.Maux;
            result.CabinDepth = cabinInfo.CabinDepth;
            result.CabinHeight = cabinInfo.CabinHeight;
            result.CabinWidth = cabinInfo.CabinWidth;
            result.WallMaterialTypeId = cabinInfo.WallMaterialTypeId;
            result.BedMaterialTypeId = cabinInfo.BedMaterialTypeId;
            result.CarWeight = cabinInfo.CarWeight;
            result.CabinTrayHeight = cabinInfo.CabinTrayHeight;
            result.HasLightSensor = cabinInfo.HasLightSensor;
            result.HasCarLockDoor = cabinInfo.HasCarLockDoor;


            var cabinAntiShock = await dataContext.CabinAntiShocksInformations.FindAsync(Id);
            result.CabinAntiShockInstallationTypeId = cabinAntiShock.CabinAntiShockInstallationTypeId;
            result.CabinAntiShockTypeId = cabinAntiShock.CabinAntiShockTypeId;


            var cwAntiShock = await dataContext.CounterWightAntiShocksInformations.FindAsync(Id);
            result.CounterWeightInstallationTypeId = cwAntiShock.CounterWeightInstallationTypeId;


            var cabinDoor = await dataContext.CabinDoors.FindAsync(Id);
            result.EnteringDepth = cabinDoor.EnteringDepth;
            result.CabinDoorDepth = cabinDoor.CabinDoorDepth;

            result.FloorDoorsInformation = await dataContext.FloorDoorsInformations.FindAsync(Id);
            result.CabinDoor = await dataContext.CabinDoors.FindAsync(Id);
            result.DoorLockInformations = await dataContext.MechanicalDoorLockInformations.Where(x => x.Id == Id).ToListAsync();
            result.CounterWightAntiShocksInformations = await dataContext.CounterWightAntiShocksInformations.Where(x => x.Id == Id).ToListAsync();
            result.SafetyBrakesInformations = await dataContext.SafetyBrakesInformations.Where(x => x.Id == Id).ToListAsync();
            result.CabinAntiShocksInformations = await dataContext.CabinAntiShocksInformations.Where(x => x.Id == Id).ToListAsync();
            result.GovernerInformations = await dataContext.GovernerInformations.Where(x => x.Id == Id).ToListAsync();
            result.SteeringControlInformation = await dataContext.SteeringControlInformations.FindAsync(Id);
            result.EnginRoomInformation = await dataContext.EngineInformations.FindAsync(Id);
            result.TractionPulleiesInformations = await dataContext.TractionPulleiesInformations.Where(x => x.Id == Id).ToListAsync();

            return new ResponseModel<TechnicalInformationModel>
            {
                Succeed = true,
                Data = result,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}
