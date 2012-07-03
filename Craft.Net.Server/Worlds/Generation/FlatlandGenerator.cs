using System;
using Craft.Net.Server.Blocks;

namespace Craft.Net.Server.Worlds.Generation
{
    public class FlatlandGenerator : IWorldGenerator
    {
        public FlatlandGenerator()
        {
        }

        public Chunk GenerateChunk(Vector3 Position)
        {
            Chunk chunk = new Chunk(Position);
            for (int x = 0; x < 16; x++)
            {
                for (int z = 0; z < 16; z++)
                {
                    for (int y = 1; y < 15; y++)
                        chunk.SetBlock(new Vector3(x, y, z), new DirtBlock());
                    chunk.SetBlock(new Vector3(x, 0, z), new BedrockBlock());
                    chunk.SetBlock(new Vector3(x, 15, z), new GrassBlock());
                }
            }
            return chunk;
        }

        public string LevelType
        {
            get
            {
                return "FLAT";
            }
        }

        public double Seed { get; set; }

        public Vector3 SpawnPoint
        {
            get
            {
                return new Vector3(0, 16, 0);
            }
        }
    }
}

